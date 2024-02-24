import React from "react";
import '../css/header.css'

const Header = ({ onInputChange }) => {

  const applyChangeData = (event) => {
    onInputChange(event.target.value)
  }

  return (
    <div class="header">
        <h1>Who are you looking for?</h1>
        <div class="search-bar">
          <svg class="search-icon" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="30" height="30" viewBox="0 0 48 48">                <path d="M 20.5 6 C 12.509634 6 6 12.50964 6 20.5 C 6 28.49036 12.509634 35 20.5 35 C 23.956359 35 27.133709 33.779044 29.628906 31.75 L 39.439453 41.560547 A 1.50015 1.50015 0 1 0 41.560547 39.439453 L 31.75 29.628906 C 33.779044 27.133709 35 23.956357 35 20.5 C 35 12.50964 28.490366 6 20.5 6 z M 20.5 9 C 26.869047 9 32 14.130957 32 20.5 C 32 23.602612 30.776198 26.405717 28.791016 28.470703 A 1.50015 1.50015 0 0 0 28.470703 28.791016 C 26.405717 30.776199 23.602614 32 20.5 32 C 14.130953 32 9 26.869043 9 20.5 C 9 14.130957 14.130953 9 20.5 9 z"></path>
            </svg>
            <input 
              type="text"
              name="q"
              onChange={applyChangeData}
              placeholder="E.g. Pikachu"></input>
            <button type="submit">
                Go
            </button>
        </div>
    </div>
  );
};

export default Header;