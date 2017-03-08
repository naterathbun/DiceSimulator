using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;


namespace DiceSimulator
{
    public partial class MainWindow : Window
    {
        public string CharacterFilePath { get; set; }
        public Dictionary<string, int> character { get; set; } = new Dictionary<string, int>();
        public string CharacterName { get; set; }
        public string CharacterClass { get; set; }

        public Dice FourSidedDie = new Dice(4);
        public Dice SixSidedDie = new Dice(6);
        public Dice EightSidedDie = new Dice(8);
        public Dice TenSidedDie = new Dice(10);
        public Dice TwelveSidedDie = new Dice(12);
        public Dice TwentySidedDie = new Dice(20);
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void LoadCharacterButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileBrowserAndSetFilePath();
            if (this.CharacterFilePath != null)
            {
                SetCharacterStatsFromFile(CharacterFilePath);
                SetCharacterNameClass();
                UpdateFormStats();
                SetLoadCharacterButtonColorToDefault();
                SetRollButtonsToColors();
            }
        }

        private void SetCharacterNameClass()
        {
            string[] nameAndClass = System.IO.Path.GetFileNameWithoutExtension(CharacterFilePath).Split(' ');
            if (nameAndClass.Length == 2)
            {
                this.CharacterName = nameAndClass[0];
                this.CharacterClass = nameAndClass[1];
            }
        }

        public void OpenFileBrowserAndSetFilePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SetFilePathOfTextFile(openFileDialog);
            }
        }

        public void SetFilePathOfTextFile(OpenFileDialog openFileDialog)
        {
            this.CharacterFilePath = openFileDialog.FileName;
        }

        private bool CharacterFileIsLoaded()
        {
            return (CharacterFilePath != null);
        }

        public void SetCharacterStatsFromFile(string filePath)
        {
            int linesInTextFile = File.ReadLines(filePath).Count();

            using (StreamReader sr = new StreamReader(filePath))
            {
                this.character.Clear();
                while (!sr.EndOfStream)
                {
                    this.character.Add(sr.ReadLine(), Convert.ToInt32(sr.ReadLine()));
                }
            }
        }

        public void UpdateFormStats()
        {
            this.CharacterNameLabel.Content = this.CharacterName;
            this.CharacterClassLabel.Content = this.CharacterClass + ", Level " + character["Level"];

            this.ArmorClassValue.Content = character["ArmorClass"];
            this.InitiativeValue.Content = character["Initiative"];
            this.SpeedValue.Content = character["Speed"];
            this.HPValue.Content = character["MaxHP"];

            this.StrengthValue.Content = character["Strength"];
            this.DexterityValue.Content = character["Dexterity"];
            this.ConstitutionValue.Content = character["Constitution"];
            this.IntelligenceValue.Content = character["Intelligence"];
            this.WisdomValue.Content = character["Wisdom"];
            this.CharismaValue.Content = character["Charisma"];

            this.StrengthBonus.Content = character["BonusStrength"];
            this.DexterityBonus.Content = character["BonusDexterity"];
            this.ConstitutionBonus.Content = character["BonusConstitution"];
            this.IntelligenceBonus.Content = character["BonusIntelligence"];
            this.WisdomBonus.Content = character["BonusWisdom"];
            this.CharismaBonus.Content = character["BonusCharisma"];

            this.SavesValues.Content = character["SaveStrength"] + "\n" + character["SaveDexterity"] + "\n" + character["SaveConstitution"] + "\n" + character["SaveIntelligence"] + "\n" + character["SaveWisdom"] + "\n" + character["SaveCharisma"];
            this.SkillsValues.Content = character["Acrobatics"] + "\n" + character["AnimalHandling"] + "\n" + character["Arcana"] + "\n" + character["Athletics"] + "\n" + character["Deception"] + "\n" + character["History"] + "\n" + character["Insight"] + "\n" + character["Intimidation"] + "\n" + character["Investigation"] + "\n" + character["Medicine"] + "\n" + character["Nature"] + "\n" + character["Perception"] + "\n" + character["Performance"] + "\n" + character["Persuasion"] + "\n" + character["Religion"] + "\n" + character["SleightOfHand"] + "\n" + character["Stealth"] + "\n" + character["Survival"];
        }

        private void DisplayRollMessage(string rollDescription, int roll, string statToCheck)
        {
            MessageBox.Show(rollDescription + "...\n\nRolled: " + roll.ToString() + "\n     +\nBonus: " + this.character[statToCheck] + "\n----------\nTotal: " + (roll + this.character[statToCheck]));
        }

        private void DisplayPlainRollMessage(string diceType, int roll)
        {
            MessageBox.Show("Rolled a " + diceType + "...\n----------\nTotal: " + roll.ToString());
        }

        public void SetLoadCharacterButtonColorToDefault()
        {
            LoadCharacterButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
        }

        public void SetRollButtonsToColors()
        {
            SolidColorBrush red = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8080"));
            SolidColorBrush green = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#80ff80"));
            SolidColorBrush blue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8080ff"));
            SolidColorBrush purple = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff80ff"));
            SolidColorBrush orange = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffbf80"));
            SolidColorBrush yellow = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffff80"));

            StrengthRollButton.Background = red;
            RollStrengthSaveButton.Background = red;
            AthleticsRollButton.Background = red;

            DexterityRollButton.Background = green;
            RollDexteritySaveButton.Background = green;
            AcrobaticsRollButton.Background = green;
            SleightOfHandRollButton.Background = green;
            StealthRollButton.Background = green;

            ConstitutionRollButton.Background = blue;
            RollConstitutionSaveButton.Background = blue;

            IntelligenceRollButton.Background = purple;
            RollIntelligenceSaveButton.Background = purple;
            ArcanaRollButton.Background = purple;
            HistoryRollButton.Background = purple;
            InvestigationRollButton.Background = purple;
            NatureRollButton.Background = purple;
            ReligionRollButton.Background = purple;

            WisdomRollButton.Background = orange;
            RollWisdomSaveButton.Background = orange;
            AnimalHandlingRollButton.Background = orange;
            InsightRollButton.Background = orange;
            MedicineRollButton.Background = orange;
            PerceptionRollButton.Background = orange;
            SurvivalRollButton.Background = orange;

            CharismaRollButton.Background = yellow;
            RollCharismaSaveButton.Background = yellow;
            DeceptionRollButton.Background = yellow;
            IntimidationRollButton.Background = yellow;
            PerformanceRollButton.Background = yellow;
            PersuasionRollButton.Background = yellow;
        }


        // Roll Main Stat Checks
        private void StrengthRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Strength Check", TwentySidedDie.Roll(), "BonusStrength");
            }
        }

        private void DexterityRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Dexterity Check", TwentySidedDie.Roll(), "BonusDexterity");
            }
        }

        private void ConstitutionRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Constitution Check", TwentySidedDie.Roll(), "BonusConstitution");
            }
        }

        private void IntelligenceRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intelligence Check", TwentySidedDie.Roll(), "BonusIntelligence");
            }
        }

        private void WisdomRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Wisdom Check", TwentySidedDie.Roll(), "BonusWisdom");
            }
        }

        private void CharismaRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Charisma Check", TwentySidedDie.Roll(), "BonusCharisma");
            }
        }


        // Roll Main Stat Saving Throws
        private void RollStrengthSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Strength Saving Throw", TwentySidedDie.Roll(), "SaveStrength");
            }
        }

        private void RollDexteritySaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Dexterity Saving Throw", TwentySidedDie.Roll(), "SaveDexterity");
            }
        }

        private void RollConstitutionSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Constitution Saving Throw", TwentySidedDie.Roll(), "SaveConstitution");
            }
        }

        private void RollIntelligenceSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intelligence Saving Throw", TwentySidedDie.Roll(), "SaveIntelligence");
            }
        }

        private void RollWisdomSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Wisdom Saving Throw", TwentySidedDie.Roll(), "SaveWisdom");
            }
        }

        private void RollCharismaSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Charisma Saving Throw", TwentySidedDie.Roll(), "SaveCharisma");
            }
        }


        // Roll Skill Checks
        private void AcrobaticsRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Acrobatics Check", TwentySidedDie.Roll(), "Acrobatics");
            }
        }

        private void AnimalHandlingRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Animal Handling Check", TwentySidedDie.Roll(), "AnimalHandling");
            }
        }

        private void ArcanaRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Arcana Check", TwentySidedDie.Roll(), "Arcana");
            }
        }

        private void AthleticsRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Athletics Check", TwentySidedDie.Roll(), "Athletics");
            }
        }

        private void DeceptionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Deception Check", TwentySidedDie.Roll(), "Deception");
            }
        }

        private void HistoryRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a History Check", TwentySidedDie.Roll(), "History");
            }
        }

        private void InsightRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Insight Check", TwentySidedDie.Roll(), "Insight");
            }
        }

        private void IntimidationRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intimidation Check", TwentySidedDie.Roll(), "Intimidation");
            }
        }

        private void InvestigationRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Investigation Check", TwentySidedDie.Roll(), "Investigation");
            }
        }

        private void MedicineRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Medicine Check", TwentySidedDie.Roll(), "Medicine");
            }
        }

        private void NatureRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Nature Check", TwentySidedDie.Roll(), "Nature");
            }
        }

        private void PerceptionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Perception Check", TwentySidedDie.Roll(), "Perception");
            }
        }

        private void PerformanceRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Performance Check", TwentySidedDie.Roll(), "Performance");
            }
        }

        private void PersuasionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Persuasion Check", TwentySidedDie.Roll(), "Persuasion");
            }
        }

        private void ReligionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Religion Check", TwentySidedDie.Roll(), "Religion");
            }
        }

        private void SleightOfHandRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Sleight of Hand Check", TwentySidedDie.Roll(), "SleightOfHand");
            }
        }

        private void StealthRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Stealth Check", TwentySidedDie.Roll(), "Stealth");
            }
        }

        private void SurvivalRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Survival Check", TwentySidedDie.Roll(), "Survival");
            }
        }


        // Roll for Initiative
        private void RollInitiativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled for Initiative", TwentySidedDie.Roll(), "Initiative");
            }
        }


        // Roll Generic Dice
        private void D20Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d20", TwentySidedDie.Roll());
            }
        }

        private void D12Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d12", TwelveSidedDie.Roll());
            }
        }

        private void D10Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d10", TenSidedDie.Roll());
            }
        }

        private void D8Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d8", EightSidedDie.Roll());
            }
        }

        private void D6Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d6", SixSidedDie.Roll());
            }
        }

        private void D4Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d4", FourSidedDie.Roll());
            }
        }


        // HP Buttons
        private void DecreaseHPButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded() && Convert.ToInt32(this.HPValue.Content) > 0)
            {
                this.HPValue.Content = Convert.ToInt32(this.HPValue.Content) - 1;
            }
        }

        private void IncreaseHPButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded() && Convert.ToInt32(this.HPValue.Content) < this.character["MaxHP"])
            {
                this.HPValue.Content = Convert.ToInt32(this.HPValue.Content) + 1;
            }
        }

    }
}
