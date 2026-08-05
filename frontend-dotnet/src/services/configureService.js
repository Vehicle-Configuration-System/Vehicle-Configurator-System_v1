const API_URL = "http://localhost:5115/api/configuration-options";

export const getConfigurationOptions = async (modelId) => {

    const response = await fetch(`${API_URL}/${modelId}`);

    if (!response.ok) {

        throw new Error("Unable to fetch configuration");

    }

    return await response.json();

};