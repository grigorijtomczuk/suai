package com.grigorijtomczuk.dbuser.ui.fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.findNavController
import androidx.navigation.fragment.navArgs
import com.grigorijtomczuk.dbuser.data.db.entity.Motorcycle
import com.grigorijtomczuk.dbuser.databinding.FragmentUpdateMotorcycleBinding
import com.grigorijtomczuk.dbuser.ui.viewmodel.MotorcycleViewModel

class UpdateMotorcycleFragment : Fragment() {

    private var _binding: FragmentUpdateMotorcycleBinding? = null
    private val binding get() = _binding!!

    private lateinit var motorcycleViewModel: MotorcycleViewModel
    private val args by navArgs<UpdateMotorcycleFragmentArgs>()

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentUpdateMotorcycleBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        motorcycleViewModel = ViewModelProvider(this).get(MotorcycleViewModel::class.java)

        motorcycleViewModel.getMotorcycle(args.motorcycleId).observe(viewLifecycleOwner) { motorcycle ->
            motorcycle?.let {
                binding.etBrandUpdate.setText(it.brand)
                binding.etModelUpdate.setText(it.model)
                binding.etYearUpdate.setText(it.year.toString())
            }
        }

        binding.btnUpdate.setOnClickListener {
            val brand = binding.etBrandUpdate.text.toString()
            val model = binding.etModelUpdate.text.toString()
            val year = binding.etYearUpdate.text.toString().toIntOrNull()

            if (brand.isNotEmpty() && model.isNotEmpty() && year != null) {
                val updatedMotorcycle = Motorcycle(args.motorcycleId, brand, model, year)
                motorcycleViewModel.update(updatedMotorcycle)
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