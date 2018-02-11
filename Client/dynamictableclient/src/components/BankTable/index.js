import React, {Component} from 'react';
import BankRow from '../BankRow';
import './style.css';

export default class BankTable extends Component{
    render() {
        const bankRowElement = this.props.bankRows.map(bankRow =>
            <BankRow bankRow={bankRow} key={bankRow.id}/>
        )
        const tableName = 'Dynamic table';
        const captionName = <caption className='bankTableCaption'>{tableName}</caption>;
        const columnNames =
            <tr className='bankTableTr'>
                <th className='bankTableTh'>Instrument</th>
                <th className='bankTableTh'>BestBid</th>
                <th className='bankTableTh'>BestOffer</th>
            </tr>;

        return (
            <table className='bankTable'>
                {captionName}
                <thead>
                {columnNames}
                </thead>
                <tbody>
                {bankRowElement}
                </tbody>
            </table>
        );
    }
}
