const express = require('express')
const bodyParser = require("body-parser");
const got = require('got');
const path = require('path');

const app = express()
const port = 3000

app.use(express.static('public'));
app.set("view engine", "pug");
app.set("views", path.join(__dirname, "views"));
app.use(bodyParser.json());

app.listen(port, () => {
  console.log(`Demo Web application listening at http://localhost:${port}`)
})

app.get('/', (req, res) => {
  res.render('index');
})

app.get('/orders', async (req, res) => {
    const status = req.query.status || 'draft';
    console.log("Getting order for status: " + status);
    const baseUrl = process.env.API_ENDPOINT || 'http://localhost:5000';
    const url = `${baseUrl}/orders?status=${status}`;
    const orders = await got(url).json();
    res.render('orders', {title: 'Orders', message: 'List of Orders', orders: orders});
})

app.post('/orders', async (req, res) => {
    const order = req.body;
    const json = JSON.stringify(order);
    console.log(`Posting new order: ${json}`);
    const baseUrl = process.env.API_ENDPOINT || 'http://localhost:5000';
    const url = `${baseUrl}/orders`;
    const result = await got.post(url, { json: order });
    console.log(result);
})
