import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

function InvoicePage() {

    const navigate = useNavigate();

    // ---------------------------------------
    // State Variables
    // ---------------------------------------
    const [invoice, setInvoice] = useState(null);
    const [loading, setLoading] = useState(false);

    // ---------------------------------------
    // Session Storage Data
    // ---------------------------------------
    const segment =
        JSON.parse(sessionStorage.getItem("selectedSegment"));

    const manufacturer =
        JSON.parse(sessionStorage.getItem("selectedManufacturer"));

    const model =
        JSON.parse(sessionStorage.getItem("selectedModel"));

    const quantity =
        JSON.parse(sessionStorage.getItem("selectedQuantity"));

    const configuration =
        JSON.parse(sessionStorage.getItem("selectedConfiguration"));

    // ---------------------------------------
    // Load Invoice
    // ---------------------------------------
    useEffect(() => {

        // Fetch invoice data from backend

    }, []);

    // ---------------------------------------
    // Event Handlers
    // ---------------------------------------
    function handlePrint() {

        // Print Invoice

    }

    function handleDownload() {

        // Download Invoice

    }

    function handleHome() {

        navigate("/");

    }

    // ---------------------------------------
    // Page UI
    // ---------------------------------------
    return (
        <div className="container mt-4">

            {/* Invoice Heading */}

            {/* Customer Details */}

            {/* Vehicle Details */}
            {/* Segment */}
            {/* Manufacturer */}
            {/* Model */}
            {/* Quantity */}

            {/* Selected Configuration */}

            {/* Price Details */}
            {/* Base Price */}
            {/* Option Price */}
            {/* GST */}
            {/* Total Price */}

            {/* Invoice Summary */}

            {/* Action Buttons */}
            {/* Print */}
            {/* Download */}
            {/* Home */}

        </div>
    );
}

export default InvoicePage;