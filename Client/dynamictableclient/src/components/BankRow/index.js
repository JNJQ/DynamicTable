import React, {PureComponent} from 'react';
import '../BankTable/style.css';

export default class BankRow extends PureComponent{
    render() {
        const {bankRow} = this.props;
        return (
            <tr className='bankTableTr'>
                <td className='bankTableTd'>{bankRow.instrument}</td>
                <td className='bankTableTd'>{bankRow.bestBid}</td>
                <td className='bankTableTd'>{bankRow.bestOffer}</td>
            </tr>
        );
    };
}
