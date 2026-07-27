import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

function ConfigurePage() {

    const navigate = useNavigate();
    const { modelId } = useParams();

    // -----------------------------
    // State Variables
    // -----------------------------
    const [configuration, setConfiguration] = useState({});
    const [loading, setLoading] = useState(false);

    // -----------------------------
    // Load Configuration Data
    // -----------------------------
    useEffect(() => {

        // Fetch configuration data here

    }, []);

    // -----------------------------
    // Event Handlers
    // -----------------------------
    const handleOptionChange = () => {

    };

    const handleReset = () => {

    };

    const handleContinue = () => {

        // Navigate to Quantity Page

    };

    // -----------------------------
    // UI
    // -----------------------------
    return (
        <div>

            {/* Page Header */}

            {/* Vehicle Details */}

            {/* Configuration Categories */}

            {/* Price Summary */}

            {/* Action Buttons */}

        </div>
    );
}

export default ConfigurePage;