package com.grigorijtomczuk.dbuser.ui.fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.findNavController
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle
import com.grigorijtomczuk.dbuser.databinding.FragmentAddMotorcycleBinding
import com.grigorijtomczuk.dbuser.ui.viewmodel.MotorcycleViewModel

class AddMotorcycleFragment : Fragment() {

    private var _binding: FragmentAddMotorcycleBinding? = null
    private val binding get() = _binding!!

    private lateinit var motorcycleViewModel: MotorcycleViewModel

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentAddMotorcycleBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        motorcycleViewModel = ViewModelProvider(this).get(MotorcycleViewModel::class.java)

        binding.btnSave.setOnClickListener {
            val brand = binding.etBrand.text.toString()
            val model = binding.etModel.text.toString()
            val year = binding.etYear.text.toString().toIntOrNull()

            if (brand.isNotEmpty() && model.isNotEmpty() && year != null) {
                val motorcycle = Motorcycle(brand = brand, model = model, year = year)
                motorcycleViewModel.insert(motorcycle)
                findNavController().popBackStack()
            } else {
                Toast.makeText(requireContext(), "Please fill all fields", Toast.LENGTH_SHORT).show()
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}