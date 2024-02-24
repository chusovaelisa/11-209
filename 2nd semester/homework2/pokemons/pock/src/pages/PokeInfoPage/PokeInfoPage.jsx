import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './PokeInfoPage.css'

const colors = new Map();
colors.set("bug", "#42946C");
colors.set('dragon', '#61C1B6');
colors.set('grass', '#5ABE79');
colors.set('steel', '#8FDFAB');
colors.set('dark', '#444649');
colors.set('flying', '#8E9BAB');
colors.set('normal', '#B98EB7');
colors.set('ghost', '#91589D');
colors.set('rock', '#5D3515');
colors.set('ground', '#815831');
colors.set('fighting', '#B95821');
colors.set('fire', '#DC3E2D');
colors.set('electric', '#F5C242');
colors.set('poison', '#6846F6');
colors.set('psychic', '#C92AB1');
colors.set('fairy', '#DC506A');
colors.set('water', '#4960E6');
colors.set('ice', '#A2DEED');

const PokeInfoPage = () => {
    const { name: pokemonName } = useParams(); // Получаем имя покемона из параметров маршрута
    const [pokemonInfo, setPokemonInfo] = useState(null);

    useEffect(() => {

        fetch(`https://pokeapi.co/api/v2/pokemon/${pokemonName}`)
            .then(response => response.json())
            .then(data => {
                setPokemonInfo(data); // Устанавливаем полученную информацию в состояние
            })
            .catch(error => {
                console.error('Error fetching Pokemon info:', error);
            });
    }, [pokemonName]); // Зависимость от pokemonName, чтобы при изменении имени загружалась новая информация о покемоне

    if (!pokemonInfo) {
        return <div>Loading...</div>;
    }

    const stats = [pokemonInfo?.stats[0], pokemonInfo?.stats[1], pokemonInfo?.stats[2], pokemonInfo?.stats[5]]

    return (
        <>
            <div className="header__wrapper">
                <div className="card">
                    <div className="card__header">
                        <div className="card__header__title">
                            <span>{`#${pokemonInfo?.id.toString().padStart(3, '0')}`}</span>
                            <p>{pokemonInfo?.name.charAt(0).toUpperCase() + pokemonInfo?.name.slice(1)}</p>
                        </div>
                        <div>
                            {
                                pokemonInfo?.types.map((item, index) => {
                                    return <button
                                        style={{backgroundColor: `${colors.get(item.type.name)}`}}
                                        className="card__header__title__btns"
                                        key={index}>
                                        {item?.type.name}
                                    </button>
                                })
                            }
                        </div>
                    </div>
                    <div className="card__body">
                        <div className="card__body_statistics">
                            <p style={{marginBottom: 5, fontWeight: 400}}>HP</p>
                            <div className="card__body__progress1">
                                <div
                                    className="card__body__progress_bar"
                                    style={{width: `${stats[0]?.base_stat}px`, backgroundColor: "#0FC06F"}}></div>
                            </div>
                            <p style={{marginBottom: 5, fontWeight: 400}}>Attack</p>
                            <div className="card__body__progress2">
                                <div
                                    className="card__body__progress_bar"
                                    style={{width: `${stats[1]?.base_stat}px`, backgroundColor: "#EE3F2D"}}></div>
                            </div>
                            <p style={{marginBottom: 5, fontWeight: 400}}>Defense</p>
                            <div className="card__body__progress3">
                                <div
                                    className="card__body__progress_bar"
                                    style={{width: `${stats[2]?.base_stat}px`, backgroundColor: "#FAD355"}}></div>
                            </div>
                            <p style={{marginBottom: 5, fontWeight: 400}}>Speed</p>
                            <div className="card__body__progress4">
                                <div
                                    className="card__body__progress_bar"
                                    style={{width: `${stats[3]?.base_stat}px`, backgroundColor: "#FE8B56"}}></div>
                            </div>
                        </div>
                        <div className="card__body__image">
                            <img
                                src={`https://raw.githubusercontent.com/pokeapi/sprites/master/sprites/pokemon/other/dream-world/${pokemonInfo?.id}.svg`}
                                alt=""/>
                        </div>
                    </div>
                    <div className="card__footer"></div>
                </div>
                <div className="card__breeding">
                    <div className="card__breeding__title">
                        <p>Breeding</p>
                    </div>
                    <div className="card__breeding__stat">
                        <div className="card__breeding__stat__height">
                            <div>
                                <h5>Height</h5>
                                <div className="card__breeding__stat__height__table">
                                    <p>2,04</p>
                                    <p>{pokemonInfo?.height.toString().length === 1
                                        ? `0.${pokemonInfo?.height} m`
                                        : `${pokemonInfo?.height.toString().slice(0, -1)}.${pokemonInfo?.height.toString().slice(-1)} m`}
                                    </p>
                                </div>
                            </div>
                            <div>
                                <h5>Weight</h5>
                                <div className="card__breeding__stat__height__table">
                                    <p>2,04</p>
                                    <p>{(pokemonInfo?.weight / 10).toFixed(1)} kg</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </>
    )
        ;
}

export default PokeInfoPage;
