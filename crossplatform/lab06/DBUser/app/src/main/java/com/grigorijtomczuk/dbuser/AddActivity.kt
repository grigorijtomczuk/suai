package com.grigorijtomczuk.dbuser

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.ViewModelProvider
import com.grigorijtomczuk.dbuser.data.Motorcyclist

class AddActivity : AppCompatActivity() {

    private lateinit var viewModel: MotorcyclistViewModel
    private lateinit var etBrand: EditText
    private lateinit var etModel: EditText
    private lateinit var etYear: EditText
    private lateinit var etOwner: EditText
    private lateinit var btnSave: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add)

        viewModel = ViewModelProvider(this)[MotorcyclistViewModel::class.java]

        etBrand = findViewById(R.id.etBrand)
        etModel = findViewById(R.id.etModel)
        etYear = findViewById(R.id.etYear)
        etOwner = findViewById(R.id.etOwner)
        btnSave = findViewById(R.id.btnSave)

        btnSave.setOnClickListener {
            val brand = etBrand.text.toString()
            val model = etModel.text.toString()
            val yearStr = etYear.text.toString()
            val owner = etOwner.text.toString()

            if (brand.isNotEmpty() && model.isNotEmpty() && yearStr.isNotEmpty() && owner.isNotEmpty()) {
                val year = yearStr.toIntOrNull()
                if (year != null) {
                    val motorcyclist =
                        Motorcyclist(brand = brand, model = model, year = year, ownerName = owner)
                    viewModel.insert(motorcyclist)
                    finish()
                } else {
                    Toast.makeText(this, "Укажите год", Toast.LENGTH_SHORT).show()
                }
            } else {
                Toast.makeText(this, "Укажите все данные", Toast.LENGTH_SHORT).show()
            }
        }
    }
}
