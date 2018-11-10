const express = require('express')
var app = express()

app.get('/', (req, res) => {
  res.sendFile(__dirname + '/index.htm')
})
app.listen('80')