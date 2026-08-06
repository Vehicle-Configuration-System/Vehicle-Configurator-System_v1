const API_URL = "http://localhost:5115/api/VehicleModel";

export const getModelsByManufacturer = async (manufacturerId, segmentId) => {

    const response = await fetch(`${API_URL}/${manufacturerId}/${segmentId}`);

    if (!response.ok) {
        throw new Error("Failed to fetch models");
    }

    return await response.json();
};