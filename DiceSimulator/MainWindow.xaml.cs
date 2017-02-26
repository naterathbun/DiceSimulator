﻿using System;
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

        // ************************************************
        // TO DO: add in all saving throws and skill checks
        // ************************************************ 


        private void LoadCharacterButtonClicked(object sender, RoutedEventArgs e)
        {
            OpenFileBrowserAndSetFilePath();
            if (this.CharacterFilePath != null)
            {
                SetCharacterStatsFromFile(CharacterFilePath);
                SetCharacterNameClass();
                UpdateFormStats();
                // ChangeLoadFileButtonColorToDefault();
                // ChangeRollButtonColors();
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

        public void SetCharacterStatsFromFile(string filePath)
        {
            int linesInTextFile = File.ReadLines(filePath).Count();

            using (StreamReader sr = new StreamReader(filePath))
            {
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


        // Roll Main Stat Saving Throws
        private void RollStrength_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RollDexterityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConstitutionRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IntelligenceRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WisdomRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CharismaRollButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // Roll Skill Checks
        private void AcrobaticsRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AnimalHandlingRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArcanaRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AthleticsRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeceptionRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HistoryRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InsightRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void IntimidationRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InvestigationRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MedicineRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NatureRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PerceptionRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PerformanceRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PersuasionRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReligionRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SleightOfHandRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StealthRollButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SurvivalRollButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // Roll for Initiative
        private void RollInitiativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(20);
                MessageBox.Show("Rolled for Initiative.\n\nRolled: " + roll.ToString() + "\n\nTotal: " + (roll + this.character["Initiative"]).ToString());
            }

        }


        // Roll Generic Dice
        private void D20Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(20);
                MessageBox.Show("Rolled a d20...\n\nResult: " + roll.ToString());
            }
        }

        private void D12Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(12);
                MessageBox.Show("Rolled a d12...\n\nResult: " + roll.ToString());
            }
        }

        private void D10Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(10);
                MessageBox.Show("Rolled a d10...\n\nResult: " + roll.ToString());
            }
        }

        private void D8Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(8);
                MessageBox.Show("Rolled a d8...\n\nResult: " + roll.ToString());
            }
        }

        private void D6Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(6);
                MessageBox.Show("Rolled a d6...\n\nResult: " + roll.ToString());
            }
        }

        private void D4Button_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null)
            {
                int roll = GetDiceRoll(4);
                MessageBox.Show("Rolled a d4...\n\nResult: " + roll.ToString());
            }
        }

        private int GetDiceRoll(int die)
        {
            return RandomNumber.Next(1, (die + 1));
        }

        // Change Current HP
        private void DecreaseHPButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null && Convert.ToInt32(this.HPValue.Content) > -1)
            {
                this.HPValue.Content = Convert.ToInt32(this.HPValue.Content) - 1;
            }
        }

        private void IncreaseHPButton_Click(object sender, RoutedEventArgs e)
        {
            if (CharacterFilePath != null && Convert.ToInt32(this.HPValue.Content) < this.character["MaxHP"])
            {
                this.HPValue.Content = Convert.ToInt32(this.HPValue.Content) + 1;
            }
        }

    }
}
