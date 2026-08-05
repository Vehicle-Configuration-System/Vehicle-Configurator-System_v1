
const API_URL = "http://localhost:5115/api/segments";

export const getAllSegments = async () => {

    const response = await fetch(API_URL);

    if (!response.ok) {
        throw new Error("Failed to fetch segments");
    }

    return await response.json();
};