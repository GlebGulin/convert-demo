import React from 'react';
import { connect } from 'react-redux';
import {setHistory} from './../Redux/convert-reducer';
import {setCurrencies} from './../Redux/convert-reducer';
// import ConvertComponent from './ConvertComponent';
import LeftSideComponent from './LeftSide/LeftSideComponent';
import RightSideComponent from './RightSide/RightSideComponent';
import styles from './Convert.module.css';
import * as axios from 'axios';
class ConvertComponent extends React.Component{
    constructor(props) {
        super(props);
       
    }
    componentDidMount(){
       
        axios.get(`http://localhost:1589/history`
        , {withCredentials: true}
        )
            .then(response =>
                {
                    debugger;
                    this.props.setCurrencies(response.data.item1);
                    this.props.setHistory(response.data.item2);
                    
                });
     

        }
        render(){
        return<div className={styles.wrapper}>
            <div className={styles.leftcontent}>
                <LeftSideComponent currencies={this.props.currencies}/>
            </div>
            <div className={styles.rightcontent}>
                <RightSideComponent historyData={this.props.historyData}/>
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
        currencies : state.convertPage.currencies
        
        

    }
}
export default connect(mapStateToProps, {setHistory, setCurrencies})(ConvertComponent);