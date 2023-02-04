const express = require('express');
const router = express.Router();
const {newAddvert, allAddvert, findAddvert,
       updateAddvert, deleteAddvert } = require('../dbAccess/dbtrans')

router.post('/newAddvert/:Custid', newAddvert);

router.get('/allAddvert', allAddvert); 

router.get('/addvert/:id', findAddvert); 

router.put('/addvert/:id', updateAddvert); 

router.delete('/addvert/:id', deleteAddvert); 







module.exports = router; 