import { useEffect, useState } from "react";
import "./App.css";

interface Property {
    id?: string;
    name: string;
    address: string;
}

function App() {
    const [properties, setProperties] = useState<Property[]>([]);
    const [newProperty, setNewProperty] = useState<Property>({ name: "", address: "" });
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetchProperties();
    }, []);

    const fetchProperties = async () => {
        const response = await fetch("http://localhost:5002/api/property");
        if (response.ok) {
            const data = await response.json();
            setProperties(data);
        }
        setLoading(false);
    };

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setNewProperty((prev) => ({ ...prev, [name]: value }));
    };

    const handleAddProperty = async (e: React.FormEvent) => {
        e.preventDefault();
        const response = await fetch("http://localhost:5002/api/property", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(newProperty),
        });
        if (response.ok) {
            const addedProperty = await response.json();
            setProperties((prev) => [...prev, addedProperty]);
            setNewProperty({ name: "", address: "" }); // Reset form
        }
    };

    return (
        <div>
            <h1>RentaEasy Properties</h1>

            <section>
                <h2>Add a New Property</h2>
                <form onSubmit={handleAddProperty}>
                    <div>
                        <label htmlFor="name">Name:</label>
                        <input
                            id="name"
                            name="name"
                            type="text"
                            value={newProperty.name}
                            onChange={handleInputChange}
                            required
                        />
                    </div>
                    <div>
                        <label htmlFor="address">Address:</label>
                        <input
                            id="address"
                            name="address"
                            type="text"
                            value={newProperty.address}
                            onChange={handleInputChange}
                            required
                        />
                    </div>
                    <button type="submit">Add Property</button>
                </form>
            </section>

            <section>
                <h2>Current Properties</h2>
                {loading ? (
                    <p>Loading properties...</p>
                ) : properties.length > 0 ? (
                    <table className="table table-striped" aria-labelledby="tableLabel">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Address</th>
                            </tr>
                        </thead>
                        <tbody>
                            {properties.map((property) => (
                                <tr key={property.id}>
                                    <td>{property.name}</td>
                                    <td>{property.address}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                ) : (
                    <p>No properties available. Add a property to get started.</p>
                )}
            </section>
        </div>
    );
}

export default App;
