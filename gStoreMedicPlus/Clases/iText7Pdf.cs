using iText;
using iText.Kernel;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.Layout.Properties;
using iText.IO.Image;
using iText.Layout.Borders;
using iText.Kernel.Events;
using iText.Kernel.Pdf.Extgstate;
using iText.Kernel.Pdf.Canvas;
using iText.Barcodes;
using iText.Kernel.Pdf.Xobject;
using gStoreMedicPlus.Models;

namespace gStoreMedicPlus.Clases
{
    public class iText7Pdf
    {
        public static byte[] CrearConsultaPdf(TbConsulta _consulta)
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);

            doc.SetMargins(35, 35, 35, 35);
            doc.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //PdfFont font = PdfFontFactory.CreateFont(Font);

            //Image background = new Image(ImageDataFactory.Create("Recursos/logo.png"));
            //pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new BackgroundImageHandler(background));

            //Image logo = new Image(ImageDataFactory.Create("Recursos/logo.jpeg"));
            //logo.SetWidth(75);
            //logo.SetHeight(75);

            //doc.Add(logo.SetHorizontalAlignment(HorizontalAlignment.CENTER));

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Style StyleCell = new Style()
                .SetBackgroundColor(new DeviceRgb(0, 104, 217))
                .SetTextAlignment(TextAlignment.CENTER);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla = new Table(1).UseAllAvailableWidth();
            Cell _cell = new Cell(1, 1).Add(new Paragraph("REPORTE DE CONSULTA" + "\n").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla.AddCell(_cell);

            doc.Add(_tabla);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos = new Table(7).UseAllAvailableWidth();
            Cell _cell_1 = new Cell(1, 1).Add(new Paragraph("Fecha: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);
                
            _cell_1 = new Cell(1, 3).Add(new Paragraph(_consulta.FechaCreado?.ToString("d")).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            _cell_1 = new Cell(1, 1).Add(new Paragraph("Teléfono: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            if (_consulta.TbPersonas.Telefono1 != null)
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Telefono1).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }
            else
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }


            doc.Add(_tabla_datos);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_2 = new Table(7).UseAllAvailableWidth();
            Cell _cell_2 = new Cell(1, 1).Add(new Paragraph("Nombre: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_2.AddCell(_cell_2);

            if (_consulta.TbPersonas.Nombre != null)
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }
            else
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }

            _cell_2 = new Cell(1, 1).Add(new Paragraph("Edad: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_2.AddCell(_cell_2);


            int edad = Clases.Misc.CalcularEdad(_consulta.TbPersonas.FechaNacimiento.Value);
            _cell_2 = new Cell(1, 2).Add(new Paragraph(edad.ToString()).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_2.AddCell(_cell_2);

            doc.Add(_tabla_datos_2);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA


            Table _tabla_datos_3 = new Table(7).UseAllAvailableWidth();
            Cell _cell_3 = new Cell(1, 1).Add(new Paragraph("Dirección: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_3.AddCell(_cell_3);

            if (_consulta.TbPersonas.Direccion != null)
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(_consulta.TbPersonas.Direccion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }
            else
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }


            doc.Add(_tabla_datos_3);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_4 = new Table(7).UseAllAvailableWidth();
            //Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Familiar: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);

            //string familiar = db.tb_dato.Where(x => x.tb_categoria_datos_a_id == 20).FirstOrDefault(x => x.tb_consultas_id == Consulta.id).descripcion.Trim();

            //_cell_4 = new Cell(1, 3).Add(new Paragraph(familiar).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);


            Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Email: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_4.AddCell(_cell_4);

            if (_consulta.TbPersonas.Correo != null)
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Correo).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }
            else
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }


            doc.Add(_tabla_datos_4);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA FECHA SIGUIENTE CITA


            Table _tabla_datos__ = new Table(7).UseAllAvailableWidth();
            Cell _cell__ = new Cell(1, 1).Add(new Paragraph("Siguiente cita: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos__.AddCell(_cell__);

            if (_consulta.ProximaCita != null)
            {
                _cell__ = new Cell(1, 6).Add(new Paragraph(_consulta.ProximaCita).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos__.AddCell(_cell__);
            }
            else
            {
                _cell__ = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }


            doc.Add(_tabla_datos__);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_linea = new Table(1).UseAllAvailableWidth();
            Cell _cell_5 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_linea.AddCell(_cell_5);
            _tabla_linea.SetBorderBottom(new SolidBorder(1f));

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_5 = new Table(7).UseAllAvailableWidth();
            Cell _cell_6 = new Cell(4, 1).Add(new Paragraph("Motivo de Consulta: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_5.AddCell(_cell_6);

            if (_consulta.Descripcion != null)
            {
                _cell_6 = new Cell(4, 6).Add(new Paragraph(_consulta.Descripcion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_5.AddCell(_cell_6);
            }
            else
            {
                _cell_6 = new Cell(4, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_5.AddCell(_cell_6);
            }

            doc.Add(_tabla_datos_5);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_6 = new Table(1).UseAllAvailableWidth();
            Cell _cell_7 = new Cell(1, 1).Add(new Paragraph("ANTECEDENTES").SetFontSize(9).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_6.AddCell(_cell_7);

            doc.Add(_tabla_6);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            /****  ANTECEDENTES      ****/
            
            Table _tabla_datos_7 = new Table(7).UseAllAvailableWidth();

            Cell _cell_8;

            //var antecedentes = db.tb_antecedentes.Where(x => x.tb_personas_id == Consulta.id_paciente).OrderByDescending(x => x.fecha_creacion).ToList();
            string[] tipo_antecedente = { "Medicos", "Quirurgicos", "Familiares", "Oftálmicos", "Alérgicos", "Otros" };

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[0]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesMedicos != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesMedicos).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[1]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesQuirurgicos != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesQuirurgicos).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[2]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesFamiliares != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesFamiliares).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[3]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesOftalmicos != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesOftalmicos).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[4]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesAlergicos != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesAlergicos).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            _cell_8 = new Cell(2, 1).Add(new Paragraph(tipo_antecedente[5]).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_7.AddCell(_cell_8);

            if (_consulta.AntecedentesOtros != null)
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph(_consulta.AntecedentesOtros).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }
            else
            {
                _cell_8 = new Cell(2, 6).Add(new Paragraph("").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_7.AddCell(_cell_8);
            }

            doc.Add(_tabla_datos_7);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            /***** TABLA 1 *****/

            Table _tabla_datos_8 = new Table(6).UseAllAvailableWidth();


            Cell _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            _cell_9 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            _cell_9 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            _cell_9 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            _cell_9 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            // OTRA LINEA

            //var tabla_A = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 7).Where(x => x.tb_categoria_datos_b_id < 3);

            _cell_9 = new Cell(1, 1).Add(new Paragraph("AVL SC").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.AvlScOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvlScOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.AvlScOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvlScOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }


            _cell_9 = new Cell(1, 1).Add(new Paragraph("AVC SC").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.AvcScOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvcScOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.AvcScOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvcScOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            //// OTRA LINEA

            _cell_9 = new Cell(1, 1).Add(new Paragraph("W").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.WOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.WOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.WOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.WOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            _cell_9 = new Cell(1, 1).Add(new Paragraph("ADD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.AddOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AddOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.AddOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AddOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }


            //// OTRA LINEA

            _cell_9 = new Cell(1, 1).Add(new Paragraph("AVL CC").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.AvlCcOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvlCcOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.AvlCcOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvlCcOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            _cell_9 = new Cell(1, 1).Add(new Paragraph("AVC CC").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_8.AddCell(_cell_9);

            if (_consulta.AvcCcOd != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvcCcOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            if (_consulta.AvcCcOs != null)
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(_consulta.AvcCcOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }
            else
            {
                _cell_9 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_8.AddCell(_cell_9);
            }

            doc.Add(_tabla_datos_8);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_9 = new Table(10).UseAllAvailableWidth();
            Cell _cell_10 = new Cell(1, 3).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("ESF.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("CIL.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("EJE.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 2).Add(new Paragraph("ADICIÓN").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 2).Add(new Paragraph("MATERIALES").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            // OTRA LINEA

            //var tabla_2 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 13).Where(x => x.tb_categoria_datos_b_id < 8);

            _cell_10 = new Cell(4, 1).Add(new Paragraph("M + S").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(2, 1).Add(new Paragraph("LEJOS.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsLejosOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsLejosOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsLejosOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsLejosOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsLejosOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }


            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsLejosOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsLejosOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsLejosOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsLejosOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsLejosOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(2, 1).Add(new Paragraph("CERCA.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsCercaOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsCercaOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsCercaOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsCercaOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsCercaOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsCercaOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsCercaOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsCercaOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsCercaOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsCercaOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(2, 1).Add(new Paragraph("M + R").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(2, 1).Add(new Paragraph("LEJOS.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MrLejosOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MrLejosOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MrLejosOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MrLejosOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MrLejosOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MrLejosOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MrLejosOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MrLejosOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MrLejosOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MrLejosOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("DIP").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //var dip = db.tb_dato.Where(x => x.tb_categoria_datos_a_id == 19).Where(x => x.tb_categoria_datos_b_id == 9).FirstOrDefault(x => x.tb_consultas_id == Consulta.id);

            if (_consulta.Dip != null)
            {
                _cell_10 = new Cell(1, 9).Add(new Paragraph(_consulta.Dip).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 9).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            doc.Add(_tabla_datos_9);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            //Document doc2 = new Document(pdfDocument, PageSize.LETTER);
            //doc2.SetMargins(35, 35, 35, 35);
            //doc2.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //doc2.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_10 = new Table(6).UseAllAvailableWidth();
            Cell _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            _cell_11 = new Cell(1, 2).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            _cell_11 = new Cell(1, 2).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            //// OTRA LINEA

            // var tabla_3 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 19).Where(x => x.tb_categoria_datos_b_id < 3);

            _cell_11 = new Cell(1, 2).Add(new Paragraph("LH").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            if (_consulta.LhOd != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.LhOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            if (_consulta.LhOs != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.LhOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            //// OTRA LINEA

            _cell_11 = new Cell(1, 2).Add(new Paragraph("BUT").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            if (_consulta.ButOd != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.ButOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            if (_consulta.ButOs != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.ButOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            //// OTRA LINEA

            _cell_11 = new Cell(1, 2).Add(new Paragraph("PIO").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            if (_consulta.PioOd != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.PioOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            if (_consulta.PioOs != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.PioOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            //// OTRA LINEA

            _cell_11 = new Cell(1, 2).Add(new Paragraph("EXC.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            if (_consulta.ExcOd != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.ExcOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            if (_consulta.ExcOs != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.ExcOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            //// OTRA LINEA

            _cell_11 = new Cell(1, 2).Add(new Paragraph("FOI").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_10.AddCell(_cell_11);

            if (_consulta.FoiOd != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.FoiOd).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            if (_consulta.FoiOs != null)
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(_consulta.FoiOs).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_10.AddCell(_cell_11);
            }

            doc.Add(_tabla_datos_10);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA  IMPRESION CLINICA

            // var tabla_4 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 23).Where(x => x.tb_categoria_datos_b_id < 13);

            Table _tabla_datos_11 = new Table(7).UseAllAvailableWidth();
            Cell _cell_ = new Cell(4, 1).Add(new Paragraph("Impresión Clínica: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_11.AddCell(_cell_);

            if (_consulta.ImpresionClinica != null)
            {
                _cell_11 = new Cell(4, 6).Add(new Paragraph(_consulta.ImpresionClinica).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_11.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(4, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_11.AddCell(_cell_11);
            }

            doc.Add(_tabla_datos_11);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA  TRATAMIENTO

            // var tabla_5 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 23).Where(x => x.tb_categoria_datos_b_id < 13);

            Table _tabla_datos_12 = new Table(7).UseAllAvailableWidth();
            Cell _cell_0 = new Cell(4, 1).Add(new Paragraph("Tratamiento: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_12.AddCell(_cell_0);

            if (_consulta.Tratamiento != null)
            {
                _cell_11 = new Cell(4, 6).Add(new Paragraph(_consulta.Tratamiento).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_12.AddCell(_cell_11);
            }
            else
            {
                _cell_11 = new Cell(4, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_12.AddCell(_cell_11);
            }

            doc.Add(_tabla_datos_12);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Close();

            byte[] byteStream = ms.ToArray();

            return byteStream;

                //File.WriteAllBytes("archivo.pdf", byteStream);
                //string pm = "CONSULTA " + _consulta.Id + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Replace(":", "_").Replace("/", "_") + ".pdf";

                //File.WriteAllBytes(pm, byteStream);

                //File(byteStream, "application/pdf", "Consulta.pdf");

                //Process.Start(pm);
                //}
                //}
            //}
            //catch (Exception ex)
            //{
                // Guardar el Error en un TXT
                //string path_error = @"" + Program.path_global + "ERRORPDF_" + DateTime.Now.ToString("s").Replace(":", "").Replace("-", "") + ".txt";
                //if (!File.Exists(path_error))
                //{
                // Create a file to write to.
                //using (StreamWriter sw = File.CreateText(path_error))
                //{
                //   sw.WriteLine("ERROR MESSEGE: " + ex.Message + " STACK: " + ex.StackTrace + " SOURCE: " + ex.Source + " MORE DETAILS: HelpLink: " + ex.HelpLink + " - Data: " + ex.Data);
                //}
                //}
                
              //  return r;
            //}
        }
        
        
        public static byte[] DatosLentesPdf(TbConsulta _consulta)
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);

            doc.SetMargins(35, 35, 35, 35);
            doc.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //PdfFont font = PdfFontFactory.CreateFont(Font);

            //Image background = new Image(ImageDataFactory.Create("Recursos/logo.png"));
            //pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new BackgroundImageHandler(background));

            //Image logo = new Image(ImageDataFactory.Create("Recursos/logo.jpeg"));
            //logo.SetWidth(75);
            //logo.SetHeight(75);

            //doc.Add(logo.SetHorizontalAlignment(HorizontalAlignment.CENTER));

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Style StyleCell = new Style()
                .SetBackgroundColor(new DeviceRgb(0, 104, 217))
                .SetTextAlignment(TextAlignment.CENTER);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla = new Table(1).UseAllAvailableWidth();
            Cell _cell = new Cell(1, 1).Add(new Paragraph("RECETA DE LENTES" + "\n").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla.AddCell(_cell);

            doc.Add(_tabla);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos = new Table(7).UseAllAvailableWidth();
            Cell _cell_1 = new Cell(1, 1).Add(new Paragraph("Fecha: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            _cell_1 = new Cell(1, 3).Add(new Paragraph(_consulta.FechaCreado?.ToString("d")).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            _cell_1 = new Cell(1, 1).Add(new Paragraph("Teléfono: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            if (_consulta.TbPersonas.Telefono1 != null)
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Telefono1).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }
            else
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }


            doc.Add(_tabla_datos);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_2 = new Table(7).UseAllAvailableWidth();
            Cell _cell_2 = new Cell(1, 1).Add(new Paragraph("Nombre: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_2.AddCell(_cell_2);

            if (_consulta.TbPersonas.Nombre != null)
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }
            else
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }           

            doc.Add(_tabla_datos_2);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA


            Table _tabla_datos_3 = new Table(7).UseAllAvailableWidth();
            Cell _cell_3 = new Cell(1, 1).Add(new Paragraph("Dirección: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_3.AddCell(_cell_3);

            if (_consulta.TbPersonas.Direccion != null)
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(_consulta.TbPersonas.Direccion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }
            else
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }


            doc.Add(_tabla_datos_3);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_4 = new Table(7).UseAllAvailableWidth();
            //Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Familiar: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);

            //string familiar = db.tb_dato.Where(x => x.tb_categoria_datos_a_id == 20).FirstOrDefault(x => x.tb_consultas_id == Consulta.id).descripcion.Trim();

            //_cell_4 = new Cell(1, 3).Add(new Paragraph(familiar).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);


            Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Email: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_4.AddCell(_cell_4);

            if (_consulta.TbPersonas.Correo != null)
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Correo).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }
            else
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }


            doc.Add(_tabla_datos_4);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_linea = new Table(1).UseAllAvailableWidth();
            Cell _cell_5 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_linea.AddCell(_cell_5);
            _tabla_linea.SetBorderBottom(new SolidBorder(1f));

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_9 = new Table(10).UseAllAvailableWidth();
            Cell _cell_10 = new Cell(1, 3).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("ESF.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("CIL.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("EJE.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 2).Add(new Paragraph("ADICIÓN").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 2).Add(new Paragraph("MATERIALES").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            // OTRA LINEA

            //var tabla_2 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 13).Where(x => x.tb_categoria_datos_b_id < 8);

            _cell_10 = new Cell(4, 1).Add(new Paragraph("M + S").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(2, 1).Add(new Paragraph("LEJOS.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsLejosOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsLejosOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsLejosOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsLejosOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsLejosOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }


            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsLejosOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsLejosOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsLejosOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsLejosOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsLejosOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsLejosOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsLejosOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(2, 1).Add(new Paragraph("CERCA.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsCercaOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsCercaOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsCercaOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsCercaOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsCercaOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MsCercaOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MsCercaOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MsCercaOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MsCercaOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MsCercaOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MsCercaOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MsCercaOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(2, 1).Add(new Paragraph("M + R").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(2, 1).Add(new Paragraph("LEJOS.").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetVerticalAlignment(VerticalAlignment.MIDDLE).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OD").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MrLejosOdEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MrLejosOdCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MrLejosOdEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOdEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MrLejosOdAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOdAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MrLejosOdMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOdMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("OS").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //// ESF

            if (_consulta.MrLejosOsEsf != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsEsf).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// CIL

            if (_consulta.MrLejosOsCil != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsCil).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// EJE

            if (_consulta.MrLejosOsEje != null)
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(_consulta.MrLejosOsEje).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// ADICION

            if (_consulta.MrLejosOsAdicion != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOsAdicion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// MATERIALES

            if (_consulta.MrLejosOsMateriales != null)
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(_consulta.MrLejosOsMateriales).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            //// OTRA LINEA

            _cell_10 = new Cell(1, 1).Add(new Paragraph("DIP").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(new SolidBorder(0.5f));
            _tabla_datos_9.AddCell(_cell_10);

            //var dip = db.tb_dato.Where(x => x.tb_categoria_datos_a_id == 19).Where(x => x.tb_categoria_datos_b_id == 9).FirstOrDefault(x => x.tb_consultas_id == Consulta.id);

            if (_consulta.Dip != null)
            {
                _cell_10 = new Cell(1, 9).Add(new Paragraph(_consulta.Dip).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }
            else
            {
                _cell_10 = new Cell(1, 9).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(new SolidBorder(0.5f));
                _tabla_datos_9.AddCell(_cell_10);
            }

            doc.Add(_tabla_datos_9);

            //Document doc2 = new Document(pdfDocument, PageSize.LETTER);
            //doc2.SetMargins(35, 35, 35, 35);
            //doc2.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //doc2.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Close();

            byte[] byteStream = ms.ToArray();

            return byteStream;
        }

        public static byte[] TramientoPdf(TbConsulta _consulta)
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);

            doc.SetMargins(35, 35, 35, 35);
            doc.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //PdfFont font = PdfFontFactory.CreateFont(Font);

            //Image background = new Image(ImageDataFactory.Create("Recursos/logo.png"));
            //pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new BackgroundImageHandler(background));

            //Image logo = new Image(ImageDataFactory.Create("Recursos/logo.jpeg"));
            //logo.SetWidth(75);
            //logo.SetHeight(75);

            //doc.Add(logo.SetHorizontalAlignment(HorizontalAlignment.CENTER));

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Style StyleCell = new Style()
                .SetBackgroundColor(new DeviceRgb(0, 104, 217))
                .SetTextAlignment(TextAlignment.CENTER);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla = new Table(1).UseAllAvailableWidth();
            Cell _cell = new Cell(1, 1).Add(new Paragraph("RECETA DE LENTES" + "\n").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla.AddCell(_cell);

            doc.Add(_tabla);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA
            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos = new Table(7).UseAllAvailableWidth();
            Cell _cell_1 = new Cell(1, 1).Add(new Paragraph("Fecha: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            _cell_1 = new Cell(1, 3).Add(new Paragraph(_consulta.FechaCreado?.ToString("d")).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            _cell_1 = new Cell(1, 1).Add(new Paragraph("Teléfono: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos.AddCell(_cell_1);

            if (_consulta.TbPersonas.Telefono1 != null)
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Telefono1).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }
            else
            {
                _cell_1 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos.AddCell(_cell_1);
            }


            doc.Add(_tabla_datos);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_2 = new Table(7).UseAllAvailableWidth();
            Cell _cell_2 = new Cell(1, 1).Add(new Paragraph("Nombre: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_2.AddCell(_cell_2);

            if (_consulta.TbPersonas.Nombre != null)
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }
            else
            {
                _cell_2 = new Cell(1, 3).Add(new Paragraph(_consulta.TbPersonas.Nombre).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_2.AddCell(_cell_2);
            }

            doc.Add(_tabla_datos_2);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA


            Table _tabla_datos_3 = new Table(7).UseAllAvailableWidth();
            Cell _cell_3 = new Cell(1, 1).Add(new Paragraph("Dirección: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_3.AddCell(_cell_3);

            if (_consulta.TbPersonas.Direccion != null)
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(_consulta.TbPersonas.Direccion).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }
            else
            {
                _cell_3 = new Cell(1, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_3.AddCell(_cell_3);
            }


            doc.Add(_tabla_datos_3);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_4 = new Table(7).UseAllAvailableWidth();
            //Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Familiar: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);

            //string familiar = db.tb_dato.Where(x => x.tb_categoria_datos_a_id == 20).FirstOrDefault(x => x.tb_consultas_id == Consulta.id).descripcion.Trim();

            //_cell_4 = new Cell(1, 3).Add(new Paragraph(familiar).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
            //_tabla_datos_4.AddCell(_cell_4);


            Cell _cell_4 = new Cell(1, 1).Add(new Paragraph("Email: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_4.AddCell(_cell_4);

            if (_consulta.TbPersonas.Correo != null)
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(_consulta.TbPersonas.Correo).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }
            else
            {
                _cell_4 = new Cell(1, 2).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_4.AddCell(_cell_4);
            }


            doc.Add(_tabla_datos_4);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_linea = new Table(1).UseAllAvailableWidth();
            Cell _cell_5 = new Cell(1, 1).Add(new Paragraph(" ").SetFontSize(10).SetTextAlignment(TextAlignment.CENTER).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_linea.AddCell(_cell_5);
            _tabla_linea.SetBorderBottom(new SolidBorder(1f));

            doc.Add(_tabla_linea);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            Table _tabla_datos_11 = new Table(7).UseAllAvailableWidth();
            Cell _cell_ = new Cell(4, 1).Add(new Paragraph("Impresión Clínica: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_11.AddCell(_cell_);

            if (_consulta.ImpresionClinica != null)
            {
                _cell_ = new Cell(4, 6).Add(new Paragraph(_consulta.ImpresionClinica).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_11.AddCell(_cell_);
            }
            else
            {
                _cell_ = new Cell(4, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_11.AddCell(_cell_);
            }

            doc.Add(_tabla_datos_11);

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA  TRATAMIENTO

            // var tabla_5 = db.tb_dato.Where(x => x.tb_consultas_id == Consulta.id).Where(x => x.tb_categoria_datos_a_id < 23).Where(x => x.tb_categoria_datos_b_id < 13);

            Table _tabla_datos_12 = new Table(7).UseAllAvailableWidth();
            Cell _cell_0 = new Cell(4, 1).Add(new Paragraph("Tratamiento: ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
            _tabla_datos_12.AddCell(_cell_0);

            if (_consulta.Tratamiento != null)
            {
                _cell_0 = new Cell(4, 6).Add(new Paragraph(_consulta.Tratamiento).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51))).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_12.AddCell(_cell_0);
            }
            else
            {
                _cell_0 = new Cell(4, 6).Add(new Paragraph(" ").SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetFontColor(new DeviceRgb(51, 51, 51)).SetBold()).SetBorder(Border.NO_BORDER).SetPadding(-1);
                _tabla_datos_12.AddCell(_cell_0);
            }

            doc.Add(_tabla_datos_12);

            //Document doc2 = new Document(pdfDocument, PageSize.LETTER);
            //doc2.SetMargins(35, 35, 35, 35);
            //doc2.SetBackgroundColor(new DeviceRgb(0.54f, 0.909f, 0.745f));

            //doc2.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Add(new Paragraph("\n").SetFontSize(3)); // SALTO DE LINEA

            doc.Close();

            byte[] byteStream = ms.ToArray();

            return byteStream;
        }

    }


    public class BackgroundImageHandler : IEventHandler
    {
        protected PdfExtGState gState;
        Image img;
        public BackgroundImageHandler(Image _img)
        {
            //gState = new PdfExtGState().SetFillOpacity(0.3f);           
            this.img = _img;
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDoc = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            Rectangle pageSize = page.GetPageSize();
            //Rectangle pageSize = new Rectangle(75f, 75f);

            PdfCanvas pdfCanvas = new PdfCanvas(page.GetLastContentStream(), page.GetResources(), pdfDoc);
            pdfCanvas.SaveState();

            Canvas canvas = new Canvas(pdfCanvas, pdfDoc, pageSize);
            canvas.Add(img.ScaleAbsolute(85f, 85f).SetMarginLeft(30f).SetMarginTop(30f));

            pdfCanvas.RestoreState();
            pdfCanvas.Release();
        }
    }
}
