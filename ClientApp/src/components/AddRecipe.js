import React from "react";
import RecipeForm from './RecipeForm';

const AddRecipe = () => {
    const handleonSubmit = (recipe) => {
        console.log(recipe)
    };

    return (
        <React.Fragment>
            <RecipeForm handleonSubmit={handleonSubmit}></RecipeForm>
        </React.Fragment>
    );
};

export default AddRecipe;