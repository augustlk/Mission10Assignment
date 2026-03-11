import { useEffect, useState } from 'react';
import type { Bowler } from "./types/bowler";

function BowlerList () {

    const [bowlers, setBowlers] = useState<Bowler[]>([]);

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
                        bowlers.map((b) => (
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