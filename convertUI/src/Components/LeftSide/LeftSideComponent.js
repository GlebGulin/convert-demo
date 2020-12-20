import React from 'react';
import styles from './Left.module.css';
const LeftSideComponent = (props) => {
    debugger;
    return(<div className={styles.leftcontent}>
        <h2>Exchange</h2>
        <input type="text"/>
        <select>
        {
                    props.currencies.map((u=>(
                    <option value={u.currencyName} key={u.currencyName.toString()}>{u.currencyName}</option>
                )))
                }
        </select>
        <input type="text"/>
        <select>
        {
                    props.currencies.map((u=>(
                    <option value={u.currencyName}>{u.currencyName}</option>
                )))
                }
        </select>
        <div><button onClick={props.oneClickExchange}>Exchange</button></div>
    </div>)
}
export default LeftSideComponent;