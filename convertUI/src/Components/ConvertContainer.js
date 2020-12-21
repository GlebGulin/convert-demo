import React from 'react';
import { connect } from 'react-redux';
import {setHistory, setCurrencies, changeAmount, addNewItem} from './../Redux/convert-reducer';
import LeftSideComponent from './LeftSide/LeftSideComponent';
import RightSideComponent from './RightSide/RightSideComponent';
import styles from './Convert.module.css';
import * as axios from 'axios';
import {GetAllHistory, PostNewItem} from './../DAL/api/DALapi';
class ConvertComponent extends React.Component{
    constructor(props) {
        super(props);
       
    }
   
    componentDidMount(){
       
        GetAllHistory().then(data =>
            {
                this.props.setCurrencies(data.item1);
                this.props.setHistory(data.item2);
            }
        )
    }
    model = {
        fromAmount: this.props.fromAmount,
        fromCurrencyId:this.props.fromCurrencyId,
        toCurrencyId: this.props.toCurrencyId
    
   
    }
    oneClickExchange = (model) => {
        this.props.addNewItem();
        
        PostNewItem(model).then(data =>
            {
                debugger;
                console.log(data);
            })
       }

        render(){
        return<div className={styles.wrapper}>
            <div className={styles.leftcontent}>
                <LeftSideComponent currencies={this.props.currencies} 
                oneClickExchange={this.oneClickExchange}
                />
            </div>
            <div className={styles.rightcontent}>
                <RightSideComponent historyData={this.props.historyData} />
            </div>
        </div>
            
        }
    }
   
debugger;
let mapStateToProps = (state) => {
    console.log(state);
    debugger;
    return {
        
        historyData :  state.convertPage.historyData,
        currencies : state.convertPage.currencies,
        fromAmount: state.convertPage.fromAmount,
        fromCurrencyId: state.convertPage.fromCurrencyId,
        toAmount: state.convertPage.toAmount,
        toCurrencyId: state.convertPage.toCurrencyId
        
        

    }
}
export default connect(mapStateToProps, {setHistory, 
    setCurrencies, 
    changeAmount, 
    addNewItem})(ConvertComponent);