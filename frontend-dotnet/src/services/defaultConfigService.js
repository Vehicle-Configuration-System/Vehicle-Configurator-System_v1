export const getDefaultConfig = async (modelId) => {

    const token = sessionStorage.getItem("token");

    const response = await fetch(
        `http://localhost:5115/api/configurations/${modelId}`,
        {
            headers: {
                "Authorization": `Bearer ${token}`
            }
        }
    );

    console.log("Status:", response.status);
    console.log("Status Text:", response.statusText);

    if (!response.ok) {
        const errorText = await response.text();
        console.log("Backend Error:", errorText);

        throw new Error(
            `Failed to load default configuration: ${response.status}`
        );
    }

    return response.json();
};