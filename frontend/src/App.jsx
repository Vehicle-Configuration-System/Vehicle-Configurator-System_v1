import { BrowserRouter, Routes, Route } from "react-router-dom";

import Navbar from "./components/Navbar";

import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import HomePage from "./pages/HomePage";
import WelcomePage from "./pages/WelcomePage";
import DefaultConfigurationPage from "./pages/DefaultConfigurationPage";
import SegmentPage from "./pages/SegmentPage";
import AboutPage from "./pages/AboutPage";
import ContactPage from "./pages/ContactPage";
import FeedbackPage from "./pages/FeedbackPage";
import ManufacturerPage from "./pages/ManufacturerPage";
import ModelPage from "./pages/ModelPage";
import QuantityPage from "./pages/QuantityPage";
import ConfigurePage from "./pages/ConfigurePage";
import VehicleSelectionPage from "./pages/VehicleSelectionPage";
import InvoicePage from "./pages/InvoicePage";
import ProtectedRoute from "./components/ProtectedRoute";
import OAuthSuccessPage from "./pages/OAuthSuccessPage";
function App() {
  return (
    <BrowserRouter>
  <Navbar />

  <Routes>

    {/* Public Routes */}
    <Route path="/" element={<HomePage />} />
    <Route path="/login" element={<LoginPage />} />
    <Route path="/register" element={<RegisterPage />} />
    <Route path="/about" element={<AboutPage />} />
    <Route path="/contact" element={<ContactPage />} />
    <Route path="/feedback" element={<FeedbackPage />} />

    {/* Protected Routes */}
<Route
 path="/oauth-success"
 element={<OAuthSuccessPage />}
/>
    <Route
      path="/welcome"
      element={
        <ProtectedRoute>
          <WelcomePage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/vehicle-selection"
      element={
        <ProtectedRoute>
          <VehicleSelectionPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/manufacturer"
      element={
        <ProtectedRoute>
          <ManufacturerPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/manufacturer/:segmentId"
      element={
        <ProtectedRoute>
          <ManufacturerPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/model/:manufacturerId"
      element={
        <ProtectedRoute>
          <ModelPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/quantity/:modelId"
      element={
        <ProtectedRoute>
          <QuantityPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/configure"
      element={
        <ProtectedRoute>
          <ConfigurePage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/configure/:modelId"
      element={
        <ProtectedRoute>
          <ConfigurePage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/default-config"
      element={
        <ProtectedRoute>
          <DefaultConfigurationPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/default-config/:modelId"
      element={
        <ProtectedRoute>
          <DefaultConfigurationPage />
        </ProtectedRoute>
      }
    />

    <Route
      path="/invoice/:invoiceId"
      element={
        <ProtectedRoute>
          <InvoicePage />
        </ProtectedRoute>
      }
    />

  </Routes>

</BrowserRouter>
  );
}

export default App;