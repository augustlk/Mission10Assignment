import { useEffect, useState } from 'react';
import type { Bowler } from "./types/bowler";

function BowlerList () {

    const [foods, setBowlers] = useState<Bowler[]>([]);

    useEffect(() => {
        const fetchBowlers = async () => {
            const response = await fetch('https://localhost:7016/api/bowlers');
            const data = await response.json();
            setBowlers(data);
        };
        fetchBowlers();
    }, []);


    return (
        <>
            <h1>Bowlers Leaque Members</h1>
            <h2>This table displays all of the members and their information!</h2>
            <table>
                <thead>
                    <tr>
                        <th>Bowler Name</th>
                        <th>Team Name</th>
                        <th>Address</th>
                        <th>City</th>
                        <th>State</th>
                        <th>Zip</th>
                        <th>Phone</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        foods.map((b) => (
                            <tr key={b.fullName}>
                                <td>{b.fullName}</td>
                                <td>{b.teamName}</td>
                                <td>{b.address}</td>
                                <td>{b.city}</td>
                                <td>{b.state}</td>
                                <td>{b.zip}</td>
                                <td>{b.phone}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </>
    );
}

export default BowlerList;