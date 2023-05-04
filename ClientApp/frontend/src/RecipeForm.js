import React, { useState } from 'react';
import axios from 'axios';

const BeerRecipeForm = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [maltAmount, setMaltAmount] = useState(0);
  const [hopAmount, setHopAmount] = useState(0);
  const [malts, setMalts] = useState([]);
  const [hops, setHops] = useState([]);

  const handleNameChange = (e) => {
    setName(e.target.value);
  };

  const handleDescriptionChange = (e) => {
    setDescription(e.target.value);
  };

  const handleMaltAmountChange = (e) => {
    setMaltAmount(e.target.value);
  };

  const handleHopAmountChange = (e) => {
    setHopAmount(e.target.value);
  };

  const handleMaltsChange = (e) => {
    setMalts(e.target.value);
  };

  const handleHopsChange = (e) => {
    setHops(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const recipe = {
        name: name,
        description: description,
        maltAmount: maltAmount,
        hopAmount: hopAmount,
        malts: malts,
        hops: hops,
    };

    axios.post('http://localhost:5432/api/recipes', recipe)
        .then(response => {
            console.log(response.data.message);
            alert('Recipe submitted successfully!');
        })
        .catch(error => {
            console.error(error);
            alert('Recipe NOT submitted successfully!');
        });
};

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name:
        <input type="text" value={name} onChange={handleNameChange} />
      </label>
      <br />
      <label>
        Description:
        <input type="text" value={description} onChange={handleDescriptionChange} />
      </label>
      <br />
      <label>
        Malt Amount:
        <input type="number" value={maltAmount} onChange={handleMaltAmountChange} />
      </label>
      <br />
      <label>
        Hop Amount:
        <input type="number" value={hopAmount} onChange={handleHopAmountChange} />
      </label>
      <br />
      <label>
        Malts:
        <input type="text" value={malts} onChange={handleMaltsChange} />
      </label>
      <br />
      <label>
        Hops:
        <input type="text" value={hops} onChange={handleHopsChange} />
      </label>
      <br />
      <input type="submit" value="Submit" />
    </form>
  );
};

export default BeerRecipeForm;
