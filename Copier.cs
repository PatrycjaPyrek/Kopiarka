using System;
using System.Collections.Generic;
using System.Text;
using Podstawowe;


namespace Zadanie1
{
    public class Copier : BaseDevice
    {
        private int printCounter = 0;
        private int scanCounter = 0;
        private int counter = 0;

        //liczba wydrukowanych dokumentow
        public int PrintCounter => printCounter;
        //liczba zeskanowanych dokumentow
        public int ScanCounter => scanCounter;
        public int Counter => counter;
        public Printer Printer { get; set; }
        public Scanner Scanner { get; set; }

        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.off)
            {
                return;
            }

            Console.WriteLine(DateTime.Now + "Print: " + document.GetFileName());

            printCounter += 1;
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (GetState() == IDevice.State.off)
            {
                document = null;
                return;
            }
            switch (formatType)
            {
                case IDocument.FormatType.JPG:
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");

                    break;
                case IDocument.FormatType.PDF:
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                    break;
                default:
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                    break;

            }
            Console.WriteLine(DateTime.Now + "Scan: " + document.GetFileName());
            scanCounter += 1;
        }
    }
}
