import React, { useRef } from 'react';
import jsPDF from 'jspdf';
import html2canvas from 'jspdf-html2canvas';
import { Document, Page, View, Text, Image, StyleSheet, PDFViewer } from '@react-pdf/renderer';
import logo from '../../Assests/logo.png';
export default function Pdf() {
  const pdfRef = useRef();

  
const styles = StyleSheet.create({
    page: {
      fontFamily: 'Helvetica',
      padding: 20,
    },
    header: {
      display: 'flex',
      flexDirection: 'row',
      justifyContent: 'space-between',
      marginBottom: 20,
    },
    logo: {
      height: 100,
      width: 100,
    },
    title: {
      fontSize: 24,
      fontWeight: 'bold',
    },
  });

  const downloadPDF = () => {
    const input = pdfRef.current;
    html2canvas(input).then((canvas) => {
      const imgData = canvas.toDataURL('image/png');
      const pdf = new jsPDF('p', 'mm', 'a4', true);
      const pdfWidth = pdf.internal.pageSize.getWidth();
      const pdfHeight = pdf.internal.pageSize.getHeight();
      const imgWidth = canvas.width;
      const imgHeight = canvas.height;
      const ratio = Math.min(pdfWidth / imgWidth, pdfHeight / imgHeight);
      const imgX = (pdfWidth - imgWidth * ratio) / 2;
      const imgY = 30;
      pdf.addImage(imgData, 'PNG', imgX, imgY, imgWidth * ratio, imgHeight * ratio);
      pdf.save('invoice.pdf');
    });
  };

  return (
    <>
      <div className='container mt-5 border p-5' ref={pdfRef}>
        <div className='row mb-4'>
          <div className='col-6'>
            <img src={require('../../Assests/logo.png')} alt='logo' height={100} width={100} />
          </div>
          <div className="col-6 text-end">
            <h1>Invoice</h1>
          </div>
        </div>
        <div className='row mb-4'>

        </div>
        <div className='row'>

        </div>
        <div className='row'>
        </div>
      </div>
      <div className='row text-center mt-5'>
        <button className='btn btn-primary' onClick={downloadPDF}>Download PDF</button>
      </div>

      <PDFViewer>
      <Document>
        <Page size="A4" style={styles.page}>
          <View style={styles.header}>
            <Image src={logo} style={styles.logo} />
            <Text style={styles.title}>Invoice</Text>
          </View>
          <View>
            {/* Add your invoice content here */}
            <Text>Invoice content goes here.</Text>
          </View>
        </Page>
      </Document>
    </PDFViewer>
    </>
  );
}
