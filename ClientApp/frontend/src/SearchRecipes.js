import React, { useState } from 'react';
import axios from 'axios';

function SearchRecipes() {
  const [query, setQuery] = useState('');
  const [recipes, setRecipes] = useState([]);

  const handleInputChange = event => {
    setQuery(event.target.value);
  };

  const handleSubmit = event => {
    event.preventDefault();
    axios.get(`/api/recipes/search?name=${query}`)
      .then(response => {
        setRecipes(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  };

  return (
    <div>
      <h2>Search for Recipes</h2>
      <form onSubmit={handleSubmit}>
        <strong>Enter Name:</strong>
        <label>
          <input type="text" value={query} onChange={handleInputChange} />
        </label>
        <button type="submit">Search</button>
      </form>
      {recipes.map(recipe => (
        <div key={recipe.id}>
          <h2>{recipe.Name}</h2>
          <p>{recipe.Description}</p>
        </div>
      ))}
    </div>
  );
}

export default SearchRecipes;