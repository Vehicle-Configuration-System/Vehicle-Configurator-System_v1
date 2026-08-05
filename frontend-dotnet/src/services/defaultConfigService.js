const API_URL = "http://localhost:5115/api/default-config";

export const getDefaultConfig = async (modelId) => {

    const response = await fetch(`${API_URL}/${modelId}`);

    if (!response.ok) {

        throw new Error("Failed to load default configuration");

    }

    return await response.json();

};