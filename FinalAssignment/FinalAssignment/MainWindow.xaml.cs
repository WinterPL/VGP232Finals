using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Documentformat;

namespace FinalAssignment
{

    public partial class MainWindow : Window
    {
        public NCharacter nCharacter = new NCharacter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Click(object sender, RoutedEventArgs e)
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

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadButton_Click(sender, e);
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveButton_Click(sender,e);
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

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Xml files (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Append))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(NCharacter));
                    xs.Serialize(fs, nCharacter);
                }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Xml files (*.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) { 
            using (FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(NCharacter));
                nCharacter = new NCharacter();
                nCharacter = (NCharacter)xs.Deserialize(fs);
            }
            }
            Name.Text = nCharacter.Name;
            origin.Text = nCharacter.Origin;
            Kind.Text = nCharacter.kind;
            Sex.Text = nCharacter.sex;
            appearence.Text = nCharacter.Appearence;
            Description.Text = nCharacter.Description;
            Title = "CharacterDocument - " + dlg.Title;
        }

        private void setAllblank()
        {
            Name.Text = "";
            origin.Text = "";
            Kind.Text = "";
            Sex.Text = "";
            appearence.Text = "";
            Description.Text = "";
        }
    }
}
