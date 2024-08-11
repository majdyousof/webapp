import React from 'react';
import Plot from 'react-plotly.js';

const Map: React.FC = () => {
    const data = [
        {
            type: 'scattermapbox',
            lat: [40.7128, 37.7749, 34.0522], // Example latitude values
            lon: [-74.0060, -122.4194, -118.2437], // Example longitude values
            mode: 'markers',
            marker: {
                size: 10,
                color: 'blue',
            },
            text: ['New York', 'San Francisco', 'Los Angeles'], // Example text labels
        },
    ];

    const layout = {
        mapbox: {
            style: 'open-street-map', // Example map style
            center: {
                lat: 37.0902, // Example center latitude
                lon: -95.7129, // Example center longitude
            },
            zoom: 3, // Example zoom level
        },
        width: 800, // Example width
        height: 600, // Example height
    };

    return <Plot data={data} layout={layout} />;
};

export default Map;