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

        public void FillAct(string nameDoc, Act a)//заполнение акта
        {
            try
            {
                
                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Belonging}", a.Belonging, nameDoc);
                this.ReplaceWordStub("{Situation}", a.Situation, nameDoc);
                this.ReplaceWordStub("{AvailabilityOfFireAutomatic}", a.AvailabilityOfFireAutomatic ? "да" : "нет", nameDoc); // возможно "да" и "нет" надо заменить на нечто иное, но тут опять же удачи, господа(хахаха)
                this.ReplaceWordStub("{FireEquipment}", a.FireEquipment, nameDoc);
                this.ReplaceWordStub("{WaterSupply}", a.WaterSupply.ToString(), nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{Terms}", a.Terms, nameDoc);
                this.ReplaceWordStub("{Cause}", a.Cause, nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                this.ReplaceWordStub("{DetectionDate}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{DetectionTime}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{DetectionMin}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LocDate}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LocTime}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LocMin}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LiqDate}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LiqTime}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{LiqMin}", DateTime.Now.ToString(), nameDoc);

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillTravel(string nameDoc, Travel a, Guard g)//заполнение путевки
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Name_division}", a.Name_division, nameDoc);
                this.ReplaceWordStub("{Obj_ignition}", a.Obj_ignition, nameDoc); 
                this.ReplaceWordStub("{Address}", a.Address, nameDoc);
                this.ReplaceWordStub("{Senior}", g.Senior, nameDoc);
                this.ReplaceWordStub("{Telephone}", a.Telephone, nameDoc);
                this.ReplaceWordStub("{FIO}", a.FIO, nameDoc);
                this.ReplaceWordStub("{InDate}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{InHour}", DateTime.Now.ToString(), nameDoc);
                this.ReplaceWordStub("{InMinutes}", DateTime.Now.ToString(), nameDoc);

               


                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportDay(string nameDoc, Act a)//заполнение отчета за день
        {
            try
            {


                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "день", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportWeek(string nameDoc, Act a)//заполнение отчета за неделю
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "неделю", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата
                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportMonth(string nameDoc, Act a)//заполнение отчета за месяц
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "месяц", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportQuarter(string nameDoc, Act a)//заполнение отчета за квартал
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "квартал", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportHalfYear(string nameDoc, Act a)//заполнение отчета за полгода
        {
            try
            {

                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "полгода", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата

                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillReportYear(string nameDoc, Act a)//заполнение отчета за год
        {
            try
            {
                Document wordDocument = wordApp.Documents.get_Item(nameDoc);
                this.ReplaceWordStub("{Period}", "год", nameDoc);
                this.ReplaceWordStub("{Parished}", a.Parished.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedChildren}", a.ParishedChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{ParishedEmployees}", a.ParishedEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{Injured}", a.Injured.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredChildren}", a.InjuredChildren.ToString(), nameDoc);
                this.ReplaceWordStub("{InjuredEmployees}", a.InjuredEmployees.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBuildings}", a.DestoyedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBuildings}", a.DamagedBuildings.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFlats}", a.DestoyedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFlats}", a.DamagedFlats.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedFloorArea}", a.DestoyedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedFloorArea}", a.DamagedFloorArea.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedTechnicks}", a.DestoyedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedTechnicks}", a.DamagedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedAgricultural}", a.DestoyedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedAgricultural}", a.DamagedAgricultural.ToString(), nameDoc);
                this.ReplaceWordStub("{DestoyedBeasts}", a.DestoyedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{DamagedBeasts}", a.DamagedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedHumans}", a.RescuedHumans.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedTechnicks}", a.RescuedTechnicks.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedBeasts}", a.RescuedBeasts.ToString(), nameDoc);
                this.ReplaceWordStub("{RescuedMaterialValues}", a.RescuedMaterialValues.ToString(), nameDoc);
                //this.ReplaceWordStub("{DateTime Indate}", DateTime.Now.ToString(), nameDoc); // В отчетах автодата
                wordDocument.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}
