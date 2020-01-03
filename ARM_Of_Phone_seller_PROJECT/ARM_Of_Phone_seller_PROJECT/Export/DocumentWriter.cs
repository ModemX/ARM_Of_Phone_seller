using ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace ARM_Of_Phone_seller_PROJECT.Export
{
    static public class DocumentWriter
    {
        static public void WriteSellsJournal(int Rows, IEnumerable<Продажа_Поля> Ebumba)
        {
            string path = Environment.CurrentDirectory + "\\Отчет о продажах.docx";
            List<Продажа_Поля> list = Ebumba.ToList();
            using (var document = DocX.Create("Отчет о продажах.docx"))
            {
                document.InsertParagraph("Отчет о продажах").FontSize(15d);
                document.InsertParagraph($"Дата создания: \"{DateTime.Now}\"");

                #region WriteTable
                var table = document.AddTable(Rows, 4);
                for (int i = 0; i < list.Count + 1; i++)
                {
                    if (i == 0)
                    {
                        table.Rows[i].Cells[0].Paragraphs[0].Append("Клиент").Bold().Alignment = Xceed.Document.NET.Alignment.center;
                        table.Rows[i].Cells[1].Paragraphs[0].Append("Модель").Bold().Alignment = Xceed.Document.NET.Alignment.center;
                        table.Rows[i].Cells[2].Paragraphs[0].Append("Дата приобретения").Bold().Alignment = Xceed.Document.NET.Alignment.center;
                        table.Rows[i].Cells[3].Paragraphs[0].Append("Стоимость").Bold().Alignment = Xceed.Document.NET.Alignment.center;
                    }
                    else
                    {
                        table.InsertRow();
                        table.Rows[i].Cells[0].Paragraphs[0].Append(list[i-1].ID_Клиента.ToString());
                        table.Rows[i].Cells[1].Paragraphs[0].Append(list[i-1].ID_Модели.ToString());
                        table.Rows[i].Cells[2].Paragraphs[0].Append(list[i-1].Дата_продажи_DataGridView.ToString());
                        table.Rows[i].Cells[3].Paragraphs[0].Append(list[i-1].Сумма_продажи.ToString());
                    }
                }
                document.InsertParagraph().InsertTableAfterSelf(table);
                #endregion

                document.Save();
            }
            System.Diagnostics.Process.Start(path);
        }
    }
}
