const API_URL = "http://localhost:5115/api/manufacturers";

export const getManufacturersBySegment = async (segmentId) => {

    const response = await fetch(`${API_URL}/${segmentId}`);

    if (!response.ok) {
        throw new Error("Failed to fetch manufacturers");
    }

    return await response.json();
};