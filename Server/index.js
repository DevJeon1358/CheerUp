const io = require('socket.io')(80)
io.set('origins', '*:*')
io.on('connection', require('./socket'))