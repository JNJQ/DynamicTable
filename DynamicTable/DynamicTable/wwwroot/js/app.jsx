class Bank extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.bank };
    }

    render() {
        return (
            <tr>
                <td>{this.state.Instruction}</td>
                <td>{this.state.BestBid}</td>
                <td>{this.state.BestOffer}</td>
            </tr>
        );
    }
}


class BankList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { banks: [] };

    }

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ banks: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }

    render() {
        return (
            <table>
                <caption>Динамическая таблица</caption>
                <Bank Instruction={bank.Instruction} BestBid={bank.BestBid} BestOffer={bank.BestOffer} />
            </table>
            );
    }
}


ReactDOM.render(
    <BankList apiUrl="/api/home" />,
    document.getElementById('content')
);
