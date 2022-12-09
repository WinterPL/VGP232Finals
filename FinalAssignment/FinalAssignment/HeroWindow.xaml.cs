using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Documentformat;

namespace FinalAssignment
{

    public partial class HeroWindow : Window
    {
        public HERO nCharacter = new HERO();
        public HeroWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {

            if (!checkspace())
            {
                string messageBoxText = "Do you want to save changes?";
                string caption = "Save";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        Save_Click(sender, e);
                        setAllblank();
                        break;
                    case MessageBoxResult.No:
                        setAllblank();
                        break;
                }
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadButton_Click(sender, e);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveButton_Click(sender, e);
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            nCharacter.Name = Name.Text;
            nCharacter.Origin = origin.Text;
            nCharacter.kind = Kind.Text;
            nCharacter.sex = Sex.Text;
            nCharacter.Appearence = appearence.Text;
            nCharacter.Description = Description.Text;
            nCharacter.SkillP.Name = SkillPName.Text;
            nCharacter.SkillP.Description = SkillPdesc.Text;
            nCharacter.Skill1.Name = Skill1Name.Text;
            nCharacter.Skill1.Description = Skill1desc.Text;
            nCharacter.Skill2.Name = Skill2Name.Text;
            nCharacter.Skill2.Description = Skill2desc.Text;
            nCharacter.Skill3.Name = Skill3Name.Text;
            nCharacter.Skill3.Description = Skill3desc.Text;
            nCharacter.ULT.Name = Skill4Name.Text;
            nCharacter.ULT.Description = Skill4desc.Text;

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Append))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(HERO));
                    xs.Serialize(fs, nCharacter);
                }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Xml files (*.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(HERO));
                    try
                    {
                        nCharacter = new HERO();
                        nCharacter = (HERO)xs.Deserialize(fs);
                    }
                    catch (Exception ex)
                    {
                        string messageBoxText = "Different Type of Character. Do you want to change a window to a suitable type?";
                        string caption = "WARNING";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult resultW;
                        resultW = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                        switch (resultW)
                        {
                            case MessageBoxResult.Yes:
                                MainWindow NormW = new MainWindow();
                                NormW.Show();
                                this.Close();
                                break;
                            case MessageBoxResult.No:
                                break;
                        }
                    }


                }
            }
            Name.Text = nCharacter.Name;
            origin.Text = nCharacter.Origin;
            Kind.Text = nCharacter.kind;
            Sex.Text = nCharacter.sex;
            appearence.Text = nCharacter.Appearence;
            SkillPName.Text = nCharacter.SkillP.Name;
            SkillPdesc.Text = nCharacter.SkillP.Description;
            Description.Text = nCharacter.Description;
            Skill1Name.Text = nCharacter.Skill1.Name;
            Skill1desc.Text = nCharacter.Skill1.Description;
            Skill2Name.Text = nCharacter.Skill2.Name;
            Skill2desc.Text = nCharacter.Skill2.Description;
            Skill3Name.Text = nCharacter.Skill3.Name;
            Skill3desc.Text = nCharacter.Skill3.Description;
            Skill4Name.Text = nCharacter.ULT.Name;
            Skill4desc.Text = nCharacter.ULT.Description;
            Title = "CharacterDocument - " + dlg.Title;
        }

        private void Change2Normal(object sender, RoutedEventArgs e)
        {
            if (checkspace())
            {
                MainWindow NormW = new MainWindow();
                NormW.Show();
                this.Close();
            }
            else {
                string messageBoxText = "Do you Want to save before change the Window?";
                string caption = "Window Change";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Question;
                MessageBoxResult result;

                result = System.Windows.MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                MainWindow NormW = new MainWindow();
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        Save_Click(sender, e);
                        NormW.Show();
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        NormW.Show();
                        this.Close();
                        break;
                }
            }

        }


        private void setAllblank()
        {
            Name.Text = "";
            origin.Text = "";
            Kind.Text = "";
            Sex.Text = "";
            appearence.Text = "";
            Description.Text = "";
            SkillPName.Text = "";
            SkillPdesc.Text = "";
            Skill1Name.Text = "";
            Skill1desc.Text = "";
            Skill2Name.Text = "";
            Skill2desc.Text = "";
            Skill3Name.Text = "";
            Skill3desc.Text = "";
            Skill4Name.Text = "";
            Skill4desc.Text = "";
        }

        private bool checkspace()
        {
            if (Name.Text == "" && origin.Text == "" && Kind.Text == "" && Sex.Text == "" && appearence.Text == "" && SkillPName.Text == "" && SkillPdesc.Text == "" && Description.Text == "" && Skill1Name.Text == "" && Skill1desc.Text == "" && Skill2Name.Text == "" &&
            Skill2desc.Text == "" && Skill3Name.Text == "" && Skill3desc.Text == "" && Skill4Name.Text == "" && Skill4desc.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
