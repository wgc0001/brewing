import React, {useState} from "react";
import {Form, Button} from 'react-bootstrap';
import {v4 as uuidv4} from 'uuid';

const RecipeForm = (props) => {
    const [recipe, setRecipe] = useState({
        Name:props.recipe ? props.book.Name : '',
        Description: props.recipe ? props.book.Description : '',
        MaltAmount: props.recipe ? props.book.MaltAmount : '',
        HopAmount: props.recipe ? props.book.HopAmount : '',
    });

    const [errorMsg, setErrorMsg] = useState('');
    const {Name, Description, MaltAmount, HopAmount} = recipe;

    const handleonSubmit = (event) => {
        event.preventDefault();
        const values = [Name, Description, MaltAmount, HopAmount];
        let errorMsg ='Something is wrong!';

        const allFieldsFilled = values.every((field) => {
            const value = `${field}`.trim();
            return value !== '' && value !== '0';
          });

        if (allFieldsFilled) {
            const recipe = {
                Id: uuidv4(),
                Name,
                Description,
                MaltAmount,
                HopAmount,
            };

            props.handleonSubmit(recipe);
        } 
        else {
            errorMsg= "Please fill out all fields!"
        }
        setErrorMsg(errorMsg);
    };

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        switch (Name) {
          case 'MaltAmount':
            if (value === '' || parseInt(value) === +value) {
              setRecipe((prevState) => ({
                ...prevState,
                [Name]: value
              }));
            }
            break;
          case 'HopAmount':
            if (value === '' || parseInt(value) === +value) {
              setRecipe((prevState) => ({
                ...prevState,
                [Name]: value
              }));
            }
            break;
          default:
            setRecipe((prevState) => ({
              ...prevState,
              [name]: value
            }));
        }
      };

    return (
        <div className="recipe-form">
            {errorMsg && <p className="errorMsg">{errorMsg}</p>}
            <Form onSubmit={handleOnSubmit}>
                <Form.Group controlId="Name">
                    <Form.Label>Recipe Name</Form.Label>
                    <form.Control 
                        className = "input-control"
                        type = "text"
                        name="Name"
                        value ={Name}
                        placeholder= "Enter the Recipe Name"
                        onChange={handleInputChange}
                        />
                </Form.Group>
                <Form.Group controlId="Description">
                    <Form.Label>Recipe Description</Form.Label>
                    <form.Control 
                        className = "input-control"
                        type = "text"
                        name="Description"
                        value ={Description}
                        placeholder= "Enter the Recipe Description"
                        onChange={handleInputChange}
                        />
                </Form.Group>
                <Form.Group controlId="MaltAmount">
                    <Form.Label>Malt Amount</Form.Label>
                    <form.Control 
                        className = "input-control"
                        type = "text"
                        name="Malt Amount"
                        value ={MaltAmount}
                        placeholder= "Enter the Amount of Malt Used"
                        onChange={handleInputChange}
                        />
                </Form.Group>
                <Form.Group controlId="MaltAmount">
                    <Form.Label>Malt Amount</Form.Label>
                    <form.Control 
                        className = "input-control"
                        type = "text"
                        name="Malt Amount"
                        value ={MaltAmount}
                        placeholder= "Enter the Amount of Malt Used"
                        onChange={handleInputChange}
                        />
                </Form.Group>
                <Button variant="primary" type="submit" className="submit-button">Submit Recipe</Button>
            </Form>
        </div>
    )
    
};
 export default RecipeForm;
