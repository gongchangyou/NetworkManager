using System;

public class XorInt {
	int key;
	
	public XorInt() : this(0) {
	}
	
	public XorInt(int value) {
		GenerateKey();
		rawValue = Xor(value);
	}

	// Non Thread Safe
	static byte[] temporaryBuffer = new byte[sizeof(int)];
	static Random temporaryRandom = new Random();

	void GenerateKey() {
		temporaryRandom.NextBytes(temporaryBuffer);
		key = BitConverter.ToInt32(temporaryBuffer, 0);
	}
	
	public int rawValue { get; private set; }
	
	public int value {
		get { return Xor(rawValue); }
		set { rawValue = Xor(value); }
	}
	
	int Xor(int x) {
		return x ^ key;
	}
	
	public static implicit operator int(XorInt xor) {
		if (xor == null) {
			return 0;
		}

		return xor.value;
	}
	
	public static implicit operator XorInt(int val) {
		return new XorInt(val);
	}

	public static XorInt operator++ (XorInt val) {
		val = val + 1;

		return val;
	}

	public static XorInt operator-- (XorInt val) {
		val = val - 1;

		return val;
	}

	public override string ToString() {
		return value.ToString();
	}
	
	public string ToString(string format) {
		return value.ToString(format);
	}

	public string ToString(IFormatProvider provider) {
		return value.ToString(provider);
	}

	public string ToString(string format, IFormatProvider provider) {
		return value.ToString(format, provider);
	}
}