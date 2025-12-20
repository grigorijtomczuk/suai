package com.grigorijtomczuk.dbuser

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.ViewModelProvider
import com.grigorijtomczuk.dbuser.data.Motorcyclist

class DeleteActivity : AppCompatActivity() {

    private lateinit var viewModel: MotorcyclistViewModel
    private lateinit var tvItemDetails: TextView
    private lateinit var btnConfirmDelete: Button
    private lateinit var btnCancel: Button
    private lateinit var currentMotorcyclist: Motorcyclist

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_delete)

        viewModel = ViewModelProvider(this)[MotorcyclistViewModel::class.java]

        tvItemDetails = findViewById(R.id.tvItemDetails)
        btnConfirmDelete = findViewById(R.id.btnConfirmDelete)
        btnCancel = findViewById(R.id.btnCancel)

        @Suppress("DEPRECATION")
        currentMotorcyclist = intent.getSerializableExtra("motorcyclist") as Motorcyclist

        tvItemDetails.text =
            "${currentMotorcyclist.brand} ${currentMotorcyclist.model}\nВладелец: ${currentMotorcyclist.ownerName}"

        btnConfirmDelete.setOnClickListener {
            viewModel.delete(currentMotorcyclist)
            finish()
        }

        btnCancel.setOnClickListener {
            finish()
        }
    }
}
