import { Link } from 'react-router-dom';
import '../components/PokemonCards.css';

const Card = ({ name, types, id }) => {

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

    return (
        <Link to={`/pokemon/${name}` }>
            <div className="pokemon-card">
                <div className="pokemon-content">
                    <div className="name-number">
                        <h2>{name.charAt(0).toUpperCase() + name.slice(1)}</h2>
                        <p>#{id.toString().padStart(3, '0')}</p>
                    </div>
                    <img src={`https://raw.githubusercontent.com/pokeapi/sprites/master/sprites/pokemon/other/dream-world/${id}.svg`} alt={name} />
                    <div className="types">
                        {types.map((type, i) => (
                            <button key={i} className="type" style={{ backgroundColor: `${colors.get(type.type.name)}` }}>{type.type.name}</button>
                        ))}
                    </div>
                </div>
            </div>
        </Link>
    );
}

export default Card;
