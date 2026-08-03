import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import jsPDF from "jspdf";
import html2canvas from "html2canvas";
function InvoicePage() {

    const { invoiceId } = useParams();

    const navigate = useNavigate();

    const [invoice, setInvoice] = useState(null);

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState("");
    const formatPrice = (price) =>
    Number(price).toLocaleString("en-IN");
const handleDownloadPdf = () => {

    window.print();

};
const handleSendEmail = () => {

    alert("Email functionality coming soon");

}
    useEffect(() => {

        fetch("http://localhost:8080/api/invoice/" + invoiceId)

            .then((response) => {

                if (!response.ok) {

                    throw new Error("Unable to fetch Invoice");

                }

                return response.json();

            })

            .then((data) => {

                console.log(data);

                setInvoice(data);

                setLoading(false);

            })

            .catch((err) => {

                console.log(err);

                setError(err.message);

                setLoading(false);

            });

    }, [invoiceId]);



    if (loading) {

        return <h2>Loading Invoice...</h2>;

    }

    if (error) {

        return <h2>{error}</h2>;

    }

    if (!invoice) {

        return <h2>No Invoice Found</h2>;

    }

const sendEmail = async () => {

    const input = document.getElementById("invoice");

const canvas = await html2canvas(input, {
    scale: 1
});
    const imgData = canvas.toDataURL("image/png");

    const pdf = new jsPDF("p", "mm", "a4");

    const imgWidth = 190;

    const imgHeight = canvas.height * imgWidth / canvas.width;

    pdf.addImage(imgData,
        "JPEG",
        10,
        10,
        imgWidth,
        imgHeight);

    const pdfBlob = pdf.output("blob");

    const formData = new FormData();

    formData.append(
        "email",
        invoice.email
    );

    formData.append(
        "pdf",
        pdfBlob,
        "Invoice.pdf"
    );

    const response = await fetch(
        "http://localhost:8080/api/email/send",
        {
            method: "POST",
            body: formData
        }
    );

    if(response.ok){

        alert("Email Sent Successfully");

    }else{

        alert("Failed to Send Email");

    }

}
const downloadPDF = async () => {

    const input = document.getElementById("invoice");

    const canvas = await html2canvas(input, {
        scale: 2,
        useCORS: true,
        scrollY: -window.scrollY
    });

    const imgData = canvas.toDataURL("image/png");

    const pdf = new jsPDF("p", "mm", "a4");

    const pdfWidth = pdf.internal.pageSize.getWidth();
    const pdfHeight = pdf.internal.pageSize.getHeight();

    const imgWidth = pdfWidth;
    const imgHeight = (canvas.height * imgWidth) / canvas.width;

    let heightLeft = imgHeight;
    let position = 0;

    pdf.addImage(imgData, "PNG", 0, position, imgWidth, imgHeight);

    heightLeft -= pdfHeight;

    while (heightLeft > 0) {

        position = heightLeft - imgHeight;

        pdf.addPage();

        pdf.addImage(
            imgData,
            "PNG",
            0,
            position,
            imgWidth,
            imgHeight
        );

        heightLeft -= pdfHeight;
    }

    pdf.save(`Invoice_${invoice.invoiceId}.pdf`);
};
return (

<div className="container mt-4">
<div id="invoice">
    <div className="card shadow">

        <div className="card-header bg-primary text-white">

            <h2>Vehicle Configuration Invoice</h2>

        </div>

        <div className="card-body">

            <div className="row">

                <div className="col-md-6">

                    <h5>Customer Details</h5>

                    <hr/>

                    <p><strong>Company :</strong> {invoice.companyName}</p>

                    <p><strong>Username :</strong> {invoice.username}</p>

                    <p><strong>Email :</strong> {invoice.email}</p>

                    <p><strong>Mobile :</strong> {invoice.mobile}</p>

                    <p><strong>GST No :</strong> {invoice.gstNo}</p>

                </div>

                <div className="col-md-6">

                    <h5>Invoice Details</h5>

                    <hr/>

                    <p><strong>Invoice Id :</strong> {invoice.invoiceId}</p>

                    <p><strong>Date :</strong> {new Date(invoice.invoiceDate).toLocaleString("en-IN")}</p>

                </div>

            </div>

            <hr/>

            <h5>Vehicle Details</h5>
<div className="text-center mb-3">
    {/* <img
        src={`http://localhost:8080/${invoice.image}`}
        alt={invoice.modelName}
        width="320"
        className="img-thumbnail"
    /> */}
</div>
            <table className="table table-bordered">

                <thead className="table-dark">

                    <tr>

                        <th>Model</th>

                        <th>Manufacturer</th>

                        <th>Segment</th>

                        <th>Quantity</th>

                    </tr>

                </thead>

                <tbody>

                    <tr>

                        <td>{invoice.modelName}</td>

                        <td>{invoice.manufacturer}</td>

                        <td>{invoice.segment}</td>

                        <td>{invoice.quantity}</td>

                    </tr>

                </tbody>

            </table>

            <hr/>

            <h5>Selected Components</h5>

            <table className="table table-striped">

                <thead className="table-secondary">

                    <tr>

                        <th>Component</th>

                        <th>Selected</th>

                        <th>Delta Price (Per Component )</th>

                    </tr>

                </thead>

  <tbody>

{
invoice.components.length === 0 ?

<tr>

<td colSpan="3" className="text-center fw-bold text-success">

Default Configuration Selected

</td>

</tr>

:

invoice.components.map((detail,index)=>(

<tr key={index}>

<td>{detail.componentName}</td>

<td>{detail.selectedComponent}</td>

<td>₹{detail.deltaPrice}</td>

</tr>

))

}

</tbody>

            </table>

            <hr/>

            <div className="row">

                <div className="col-md-6"></div>

                <div className="col-md-6">

                    <table className="table">

                        <tbody>

                            <tr>

                                <th>Total Amount</th>

                                <td>₹{formatPrice(invoice.totalAmount)}</td>

                            </tr>

                            <tr>

                                <th>GST 10%</th>

                                <td>₹{formatPrice(invoice.tax)}</td>

                            </tr>

                            <tr className="table-success">

                                <th>Grand Total</th>

                                <th>₹{formatPrice(invoice.finalAmount)}</th>

                            </tr>

                        </tbody>

                    </table>

                </div>

            </div>
</div>
            <div className="text-center mt-4">

    <button
        className="btn btn-success me-2"
        onClick={downloadPDF}
    >
        Download PDF
    </button>

    <button
        className="btn btn-primary me-2"
        onClick={sendEmail}
    >
        Send Email
    </button>

    <button
    className="btn btn-secondary"
    onClick={() => {

        sessionStorage.clear();

        navigate("/login");

    }}
>
    Logout
</button>

</div>
        </div>

    </div>

</div>

);

}

export default InvoicePage;