const API_URL = "http://localhost:8080/api/models";

export const getModelsByManufacturer = async (manufacturerId) => {

    const response = await fetch(`${API_URL}/${manufacturerId}`);

    if (!response.ok) {
        throw new Error("Failed to fetch models");
    }

    return await response.json();
};