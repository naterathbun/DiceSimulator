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
        public Random RandomNumber { get; set; } = new Random();

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

        private int GetDiceRoll(int die)
        {
            return RandomNumber.Next(1, (die + 1));
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
                DisplayRollMessage("Rolled a Strength Check", GetDiceRoll(20), "BonusStrength");
            }
        }

        private void DexterityRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Dexterity Check", GetDiceRoll(20), "BonusDexterity");
            }
        }

        private void ConstitutionRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Constitution Check", GetDiceRoll(20), "BonusConstitution");
            }
        }

        private void IntelligenceRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intelligence Check", GetDiceRoll(20), "BonusIntelligence");
            }
        }

        private void WisdomRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Wisdom Check", GetDiceRoll(20), "BonusWisdom");
            }
        }

        private void CharismaRollButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Charisma Check", GetDiceRoll(20), "BonusCharisma");
            }
        }


        // Roll Main Stat Saving Throws
        private void RollStrengthSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Strength Saving Throw", GetDiceRoll(20), "SaveStrength");
            }
        }

        private void RollDexteritySaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Dexterity Saving Throw", GetDiceRoll(20), "SaveDexterity");
            }
        }

        private void RollConstitutionSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Constitution Saving Throw", GetDiceRoll(20), "SaveConstitution");
            }
        }

        private void RollIntelligenceSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intelligence Saving Throw", GetDiceRoll(20), "SaveIntelligence");
            }
        }

        private void RollWisdomSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Wisdom Saving Throw", GetDiceRoll(20), "SaveWisdom");
            }
        }

        private void RollCharismaSaveButtonClick(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Charisma Saving Throw", GetDiceRoll(20), "SaveCharisma");
            }
        }


        // Roll Skill Checks
        private void AcrobaticsRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Acrobatics Check", GetDiceRoll(20), "Acrobatics");
            }
        }

        private void AnimalHandlingRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Animal Handling Check", GetDiceRoll(20), "AnimalHandling");
            }
        }

        private void ArcanaRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Arcana Check", GetDiceRoll(20), "Arcana");
            }
        }

        private void AthleticsRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Athletics Check", GetDiceRoll(20), "Athletics");
            }
        }

        private void DeceptionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Deception Check", GetDiceRoll(20), "Deception");
            }
        }

        private void HistoryRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a History Check", GetDiceRoll(20), "History");
            }
        }

        private void InsightRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Insight Check", GetDiceRoll(20), "Insight");
            }
        }

        private void IntimidationRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Intimidation Check", GetDiceRoll(20), "Intimidation");
            }
        }

        private void InvestigationRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled an Investigation Check", GetDiceRoll(20), "Investigation");
            }
        }

        private void MedicineRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Medicine Check", GetDiceRoll(20), "Medicine");
            }
        }

        private void NatureRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Nature Check", GetDiceRoll(20), "Nature");
            }
        }

        private void PerceptionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Perception Check", GetDiceRoll(20), "Perception");
            }
        }

        private void PerformanceRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Performance Check", GetDiceRoll(20), "Performance");
            }
        }

        private void PersuasionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Persuasion Check", GetDiceRoll(20), "Persuasion");
            }
        }

        private void ReligionRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Religion Check", GetDiceRoll(20), "Religion");
            }
        }

        private void SleightOfHandRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Sleight of Hand Check", GetDiceRoll(20), "SleightOfHand");
            }
        }

        private void StealthRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Stealth Check", GetDiceRoll(20), "Stealth");
            }
        }

        private void SurvivalRollButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled a Survival Check", GetDiceRoll(20), "Survival");
            }
        }


        // Roll for Initiative
        private void RollInitiativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayRollMessage("Rolled for Initiative", GetDiceRoll(20), "Initiative");
            }
        }


        // Roll Generic Dice
        private void D20Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d20", GetDiceRoll(20));
            }
        }

        private void D12Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d12", GetDiceRoll(12));
            }
        }

        private void D10Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d10", GetDiceRoll(10));
            }
        }

        private void D8Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d8", GetDiceRoll(8));
            }
        }

        private void D6Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d6", GetDiceRoll(6));
            }
        }

        private void D4Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFileIsLoaded())
            {
                DisplayPlainRollMessage("d4", GetDiceRoll(4));
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
