const { Client } = require('pg')
const client = new Client({
  host: 'my-postgres',
  port: 5432,
  user: 'postgres',
  password: 'Top-Secret',
  database: 'demo'
})

client.connect(err => {
  if (err) {
    console.error('connection error', err.stack)
  } else {
    console.log('-----------------------');
    console.log('Connected to PostgreSQL');
    console.log('-----------------------');
    client.query('SELECT * FROM users', (err, res) => {
        if (err) throw err
        console.log(res.rows);
        client.end()
      })
  }
})