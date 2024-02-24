import React, { useEffect, useState } from "react";
import '../components/PokemonCards.css';
import Card from './Card'
import NotFound from "./NotFound";

const MainPage = ({ filteredData }) => {

    const [poks, setPoks] = useState([]);

    useEffect(() => {
        async function getPoks() {
            try {
                const res = await fetch("https://pokeapi.co/api/v2/pokemon?limit=600");
                const data = await res.json();
                setPoks(data.results);
            } catch (error) {
                console.error("Error fetching Pokemon data:", error);
            }
        }
        getPoks();
    }, []);

    const [pokTypes, setPokTypes] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const promises = poks.map(async item => {
                    const response = await fetch(item.url);
                    return response.json();
                });
                const data = await Promise.all(promises);
                setPokTypes(data);
            } catch (error) {
                console.error("Error fetching pokemon data:", error);
            }
        };

        fetchData();
    }, [poks]);

    console.log(pokTypes)
    const filterData = pokTypes.filter((data) => data.id == filteredData
        || data.species.name.toLowerCase() == filteredData.toLowerCase()
        || data.species.name.startsWith(filteredData))
    console.log(filterData)

    return (
        <div className="pokemon-list">
            {
                filterData.length === 0
                    ? <NotFound />
                    : filterData.map(item => {
                        return <Card name={item.name} types={item.types} id={item.id} />
                    })
            }
        </div>
    );
}

export default MainPage;