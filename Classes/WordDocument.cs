using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FireDepartment.Model;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace FireDepartment.Classes
{
    class WordDocument
    {
        Microsoft.Office.Interop.Word.Application wordApp;
        public WordDocument()
        {
            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OpenDoc(string name)//открытие документа
        {
            try
            {
                object documentTemplate = name;
                wordApp.Documents.Open(documentTemplate);//-----------------
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddDoc(string NewName)
        {
            try
            {
                Word.Document wordDocument = wordApp.Documents.Add();
                wordDocument.SaveAs(NewName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddDoc(string name, string NewName)
        {
            try
            {
                object documentTemplate = name;
                Word.Document wordDocument = wordApp.Documents.Add(documentTemplate);
                wordDocument.SaveAs(NewName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CloseDoc()//закрытие документа
        {
            try
            {
                wordApp.Visible = false;
                Object saveChanges = WdSaveOptions.wdPromptToSaveChanges;
                wordApp.Quit(saveChanges, false);
                wordApp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReplaceWordStub(string stubToReplace, string text, string nameDoc)
        {
            try
            {
                wordApp.Visible = false;
                bool f1;
                Word.Document wordDocument = (Word.Document)wordApp.Documents.get_Item(nameDoc);
                do
                {
                    var range = wordDocument.Content;
                    f1 = range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
                } while (f1);
                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Test(string t, string nameDoc)
        {
            Word.Document wordDocument = (Word.Document)wordApp.Documents.get_Item(nameDoc);
            this.ReplaceWordStub("{text}", t, nameDoc);
            wordDocument.Save();
        }

        public void FillConsent(string nameDoc, Act a)//заполнение акта
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Belonging}", a.Belonging, nameDoc);
                this.ReplaceWordStub("{Situation}", a.Situation, nameDoc);

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }

}
