package com.grigorijtomczuk.dbuser.data.db.entity

import androidx.room.Entity
import androidx.room.PrimaryKey

@Entity(tableName = "motorcycles")
data class Motorcycle(
    @PrimaryKey(autoGenerate = true) val id: Int = 0,
    val brand: String,
    val model: String,
    val year: Int
)