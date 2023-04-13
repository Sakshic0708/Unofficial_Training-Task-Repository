db.createCollection('Nameofcollection',
    {
        validator: {
            $jsonSchema: {
                required: ['field1', 'field2'],
                properties: {
                    field1: {
                        bsonType: 'string',
                        description: 'must be a string and it is required'
                    },

                    field2: {
                        bsonType: 'number',
                        description: 'must be a number and it is required'
                    }
                }
            }
        },
        validationAction:'error' //warn
    })

//modify the command
db.runCommand({
    collMod:'Nameofcollection',
    validator: {
        $jsonSchema: {
            required: ['field1', 'field2','field3s'],
            properties: {
                field1: {
                    bsonType: 'string',
                    description: 'must be a string and it is required'
                },

                field2: {
                    bsonType: 'number',
                    description: 'must be a number and it is required'
                },

                field3: {
                    bsonType: 'array',
                    description: 'must be a array and it is required',
                    items:{
                        bsonType:'object',
                        required:['childFeild1','childFeild2'],
                        properties:{
                            name:{
                                bsonType:'string'
                            },
                            email:{
                                bsonType:'string'
                            }
                        }
                    }
                }
            }
        }
    },
    }
)