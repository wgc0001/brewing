import React from 'react'

const createRecipe =({onChangeForm, createRecipe}) => {
    
    return (
        <div className='container'>
            <div className ='row'>
                <div className='col-md-7 mrgnbtm'>
                    <h1>Create Recipe</h1>
                    <form>
                        <div className='row'>
                            <div className="form-group col-md-6">
                                <label>Recipe Name</label>
                                <input type='text' onChange ={(x)=>onChangeForm(x)} className='recipe-form' name='recipeName' id ="recipeName" placeholder='Recipe Name'/>
                                <label>Base Malt</label>
                                <input type='text' onChange ={(x)=>onChangeForm(x)} className='recipe-form' name='baseMaltName' id ="baseMaltName" placeholder='Base Malt Name'/>
                                <label>Base Malt Amount</label>
                                <input type='text' onChange ={(x)=>onChangeForm(x)} className='recipe-form' name='baseMaltAmount' id ="baseMaltAmount" placeholder='Base Malt Amount'/>
                                <button type="submit">
                                </button>
                            </div>  
                        </div>
                    </form>
                </div>
            </div>
        </div>
        
        
    )
}

export default createRecipe