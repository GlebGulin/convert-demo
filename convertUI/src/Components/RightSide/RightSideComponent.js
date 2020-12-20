import React from 'react';
import styles from './Right.module.css';
const RightSideComponent = (props) => {
    debugger;
    return(<div className={styles.rightcontent}>
        <h2>Exchange history</h2>
        <table>
        <tr>
            <th>Id</th>
            <th>FromCurrency</th>
            <th>FromAmount</th>
            <th>ToCurrency</th>
            <th>ToAmount</th>
            <th>Date</th>
        </tr>
        
                {
                    props.historyData.map(u=>
                        <tbody key={u.id}>
                                <td>{u.id}</td>
                                <td>{u.fromCurrency.currencyName}</td>
                                <td>{u.fromAmount}</td>
                                <td>{u.toCurrency.currencyName}</td>
                                <td>{u.toAmount}</td>
                                <td>{u.dateConvert}</td>
                        </tbody>
                        )
                }
        
        </table>
    </div>)
}
export default RightSideComponent;