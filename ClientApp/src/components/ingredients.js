import React, {Component} from 'react'
import Select from 'react-select';

const ingredientOptions = [

    {label:"Hops", value: "Hops"},
    {label:"Base Malt", value: "Base Malt"},
    {label:"Adjunct Malt", value: "Adjunct Malt"},
    {label: "Yeast", value: "Yeast"}

]

class ingredientDropDown extends React.Component  {
    render (){
        <div className ="container">
        <div className='row'>
            <div className ='col-md-4'></div>
            <div className ='col-md-4'>
                <Select options={ingredientOptions}/>
            </div>
            <div className='col-md-4'></div>
        </div>
    </div>  
    }
}

export default ingredientDropDown
 