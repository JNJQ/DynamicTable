import React from 'react';
import {render} from 'react-dom';
import BankTable from './components/BankTable';
import {mainPath} from './fixtures';
import {startPath} from './fixtures';
import Axios from 'axios';


var bankRows;

var getData = function (path) {
    Axios.get(path).then(function (result) {
        bankRows = result.data;
    })
};

getData(startPath);

setInterval(function() {
        render(<BankTable bankRows={bankRows}/>, document.getElementById('root'));
        getData(mainPath);
    }, 3000);