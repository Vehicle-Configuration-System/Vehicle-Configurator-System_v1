const BASE_URL = "http://localhost:8080/api";


// Get Segments
export async function getVehicleSegments() {

    const response = await fetch(`${BASE_URL}/segments`);

    if (!response.ok) {
        throw new Error("Unable to fetch vehicle segments");
    }

    return await response.json();

}


// Get Manufacturers by Segment
export async function getManufacturers(segmentId) {

    const response = await fetch(
        `${BASE_URL}/manufacturers/${segmentId}`
    );

    if (!response.ok) {
        throw new Error("Unable to fetch manufacturers");
    }

    return await response.json();

}


// Get Models by Manufacturer
export async function getModels(manufacturerId) {

    const response = await fetch(
        `${BASE_URL}/models/${manufacturerId}`
    );

    if (!response.ok) {
        throw new Error("Unable to fetch models");
    }

    return await response.json();

}


// Get Default Configuration
export async function getDefaultConfiguration(
    segmentId,
    manufacturerId,
    modelId,
    quantity
) {

    const response = await fetch(

        `${BASE_URL}/vehicles/default?segmentId=${segmentId}&manufacturerId=${manufacturerId}&modelId=${modelId}&quantity=${quantity}`

    );

    if (!response.ok) {
        throw new Error("Unable to fetch default configuration");
    }

    return await response.json();

}