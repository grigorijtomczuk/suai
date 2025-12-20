package com.grigorijtomczuk.dbuser.data

import androidx.room.Entity
import androidx.room.PrimaryKey
import java.io.Serializable

@Entity(tableName = "motorcyclists")
data class Motorcyclist(
    @PrimaryKey(autoGenerate = true)
    val id: Long = 0,
    val brand: String,
    val model: String,
    val year: Int,
    val ownerName: String
) : Serializable
